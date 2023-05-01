using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Xml.Linq;
using Webform.Models;

namespace Webform.Controllers
{
    public class ProductController : BaseController
    {

        [HttpGet]
        [Route("/product")]
        public ActionResult Index(string category, string created_at, string q, int page = 1)
        {

            int pageSize = 20;

            var builder = db.Products.AsQueryable();
            if (!string.IsNullOrEmpty(category))
            {
                builder = builder.Where(o => o.category.ToString().Equals(category));
            }
            if (!string.IsNullOrEmpty(created_at))
            {
                var split = created_at.Split(',');
                if (split.Length == 2)
                {
                    var start = DateTime.Parse(split[0]);
                    var end = DateTime.Parse(split[1]);
                    builder = builder.Where(o => o.created_at >= start && o.created_at <= end);
                }
            }
            if (!string.IsNullOrEmpty(q))
            {
                builder = builder.Where(o =>
                    o.name.Contains(q) ||
                    o.price.ToString().Contains(q) ||
                    o.description.Contains(q) ||
                    o.created_at.ToString().Contains(q)
                );
            }

            var products = builder.OrderByDescending(o => o.created_at)
                                .ThenByDescending(o => o.created_at)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            ViewBag.Products = products;
            ViewBag.Categories = getCategories();
            ViewBag.Paginate = new Paginate(builder.Count(), pageSize);

            return View("~/Views/Product/Index.cshtml");
        }


        [HttpGet]
        [Route("/product/create")]
        public ActionResult Create()
        {
            ViewBag.Categories = getCategories();

            return View("~/Views/Product/Create.cshtml");
        }


        [HttpGet]
        [Route("/product/edit/{id}")]
        public ActionResult Edit(int id)
        {
            ViewBag.Product = db.Products.Find(id);
            ViewBag.Categories = getCategories();

            return View("~/Views/Product/Edit.cshtml");
        }

        [HttpGet]
        [Route("/product/import")]
        public ActionResult Import()
        {
            ViewBag.Products = db.Products.ToList();

            return View("~/Views/Product/Import.cshtml");
        }

        
        [HttpPost]
        [Route("/product/process_import")]
        public ActionResult ProcessImport(FormCollection form)
        {
            Dictionary<string, string> data = form.AllKeys.ToDictionary(k => k, k => form[k]);

            if (data.Count % 3 != 0)
            {
                TempData["error"] = "Product not found or not filled";

                return RedirectToAction("Import", "Product");
            }

            List <ExpandoObject> products = new List<ExpandoObject>();
            for (int i = 0; i < data.Count / 3; i++)
            {
                dynamic product = new ExpandoObject();
                product.product_id = data[$"products[{i}][product_id]"];
                product.amount = data[$"products[{i}][amount]"];
                product.price = data[$"products[{i}][price]"];
                products.Add(product);
            }

            var import = new Import
            {
                product_price = 0,
                created_at = DateTime.Now
            };
            db.Imports.Add(import);
            db.SaveChanges();

            var sync = new Dictionary<int, ImportProduct>();
            double total = 0;
            foreach (dynamic product in products)
            {
                int productId = int.Parse(product.product_id);
                double price = double.Parse(product.price);
                int amount = int.Parse(product.amount);
                total += price * amount;

                sync[productId] = new ImportProduct
                {
                    price = price,
                    amount = amount,
                    import_id = import.id,
                    product_id = productId
                };
            }

            foreach (var item in sync)
            {
                db.ImportProducts.Add(item.Value);
            }
            db.SaveChanges();

            import.product_price = total;
            db.SaveChanges();

            TempData["success"] = "Import products successfully";

            return RedirectToAction("Index", "Product");

        }

        [HttpPost]
        [Route("/product/update/{id}")]
        public ActionResult Update(int id, HttpPostedFileBase image, FormCollection data)
        {
            if (string.IsNullOrEmpty(data["category"]) || string.IsNullOrEmpty(data["name"]) ||
                string.IsNullOrEmpty(data["price"]) || string.IsNullOrEmpty(data["description"]))
            {
                TempData["error"] = "Field must not be empty";

                return RedirectBack();
            }

            Product product = db.Products.Find(id);

            product.category = Convert.ToInt32(data["category"]);
            product.name = data["name"];
            product.price = Convert.ToDouble(data["price"]);
            product.description = data["description"];
            product.created_at = DateTime.Now;
            if (image != null && image.ContentLength > 0)
            {
                product.image = uploadFile(image);
            }
           
            db.SaveChanges();

            TempData["success"] = "Update product successfully";

            return RedirectToAction("Index", "Product");
        }




        [HttpPost]
        [Route("/product/store")]
        public ActionResult Store(HttpPostedFileBase image, FormCollection data)
        {
            if (string.IsNullOrEmpty(data["category"]) || string.IsNullOrEmpty(data["name"]) ||
                string.IsNullOrEmpty(data["price"]) || string.IsNullOrEmpty(data["description"]) ||
                image == null || image.ContentLength == 0)
            {
                TempData["error"] = "Field must not be empty";

                return RedirectBack();
            }

            db.Products.Add(new Product()
            {
                category = Convert.ToInt32(data["category"]),
                name = data["name"],
                price = Convert.ToDouble(data["price"]),
                description = data["description"],
                image = uploadFile(image),
                created_at = DateTime.Now,
            });
            db.SaveChanges();
            TempData["success"] = "Create product successfully";

            return RedirectToAction("Index", "Product");
        }



        [HttpPost]
        [Route("/product/destroy/{id}")]
        public ActionResult Destroy(int id)
        {
            Product product = db.Products.Find(id);

            try
            {
                db.Products.Remove(product);
                db.SaveChanges();
                TempData["success"] = "Delete product successfully";

                return RedirectToAction("Index", "Product");
            }
            catch (DbUpdateException)
            {
                db.Products.Add(product);
                TempData["error"] = "Can not delete because it has relation to others";

                return RedirectToAction("Index", "Product");
            }
        }

        private string uploadFile(HttpPostedFileBase image)
        {
            byte[] fileData = new byte[image.InputStream.Length];
            image.InputStream.Read(fileData, 0, fileData.Length);

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                string apiUrl = "https://api.imgbb.com/1/upload";
                string apiKey = "44c3abcbb4d3f91a34d5d66a5f232cce";
                string expiration = "0";
                string imageData = Convert.ToBase64String(fileData);

                NameValueCollection requestBody = new NameValueCollection();
                requestBody.Add("key", apiKey);
                requestBody.Add("expiration", expiration);
                requestBody.Add("image", imageData);

                byte[] responseBytes = client.UploadValues(apiUrl, "POST", requestBody);
                string response = Encoding.UTF8.GetString(responseBytes);

                dynamic jsonResponse = JsonConvert.DeserializeObject<dynamic>(response);
                string imageUrl = jsonResponse.data.image.url;


                return imageUrl;
            }
        }

        Category[] getCategories()
        {
            return new[] {
                new Category{ CategoryId = 1, CategoryName = "GOOGLE" },
                new Category{ CategoryId = 2, CategoryName = "SAMSUNG" },
                new Category{ CategoryId = 3, CategoryName = "SONY" },
                new Category{ CategoryId = 4, CategoryName = "NOKIA" },
                new Category{ CategoryId = 5, CategoryName = "LG" },
                new Category{ CategoryId = 6, CategoryName = "XIAOMI" },
                new Category{ CategoryId = 7, CategoryName = "VIVO" },
                new Category{ CategoryId = 8, CategoryName = "OPPO" },
                new Category{ CategoryId = 9, CategoryName = "ONEPLUS" },
                new Category{ CategoryId = 10, CategoryName = "HUAWEI" },
            };
        }

    }
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}