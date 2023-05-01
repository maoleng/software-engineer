using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI;
using System.Xml.Linq;
using Webform.Models;

namespace Webform.Controllers
{
    public class ImportController : BaseController
    {

        [HttpGet]
        [Route("/import")]
        public ActionResult Index(string status, string created_at, string q, int page = 1)
        {
            if (Authed() == null) return RedirectToAction("Index", "Home");

            int pageSize = 20;

            var builder = db.Imports.AsQueryable();
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

            var imports = builder.OrderByDescending(o => o.created_at)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            ViewBag.Imports = imports;
            ViewBag.Paginate = new Paginate(builder.Count(), pageSize);

            return View("~/Views/Import/Index.cshtml");
        }

        [HttpGet]
        [Route("/import/Show")]
        public ActionResult Show(int? import_id)
        {
            if (Authed() == null) return RedirectToAction("Index", "Home");

            if (import_id == null)
            {
                return new EmptyResult();
            }
            var model = getImportDetail(import_id, true);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("/import/Print")]
        public ActionResult Print(int? import_id)
        {
            if (Authed() == null) return RedirectToAction("Index", "Home");

            if (import_id == null)
            {
                return RedirectBack();
            }
            ViewBag.import = getImportDetail(import_id);

            return View("~/Views/Import/Print.cshtml");
        }


        [HttpGet]
        [Route("/import/create")]
        public ActionResult Create()
        {
            if (Authed() == null) return RedirectToAction("Index", "Home");

            ViewBag.Products = db.Products.ToList();

            return View("~/Views/Import/Create.cshtml");
        }




        [HttpPost]
        [Route("/import")]
        public ActionResult Store(FormCollection form)
        {
            if (Authed() == null) return RedirectToAction("Index", "Home");

            Dictionary<string, string> data = form.AllKeys.ToDictionary(k => k, k => form[k]);

            if (data.Count % 3 != 0)
            {
                TempData["error"] = "Product not found or not filled";

                return RedirectToAction("Import", "Product");
            }

            List<ExpandoObject> products = new List<ExpandoObject>();
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

            return RedirectToAction("Index", "Import");

        }

        private object getImportDetail(int? import_id, bool isJson = false)
        {
            var import = db.Imports
                          .Include(o => o.ImportProducts.Select(op => op.Product))
                          .FirstOrDefault(o => o.id == import_id);

            if (import == null)
            {
                return HttpNotFound();
            }

            List<object> products = new List<object>();
            double productPrice = 0;
            foreach (var importProduct in import.ImportProducts)
            {
                var price = importProduct.price;
                var amount = importProduct.amount;
                var sumPrice = price * amount;

                products.Add(new
                {
                    name = importProduct.Product.name,
                    amount = amount,
                    price = formatMoney(price),
                    sum = formatMoney(sumPrice)
                });
                productPrice += sumPrice;
            }
            var total = productPrice;


            if (isJson)
            {
                var model = new
                {
                    import_id = import.id,
                    products = products,
                    total = formatMoney(total),
                    created_at = import.created_at.ToString("yyyy/MM/dd HH:mm"),
                };

                return model;
            }


            List<ExpandoObject> resultProducts = new List<ExpandoObject>();
            foreach (var importProduct in import.ImportProducts)
            {
                var price = importProduct.price;
                var amount = importProduct.amount;
                var sumPrice = price * amount;

                dynamic resultProduct = new ExpandoObject();
                resultProduct.name = importProduct.Product.name;
                resultProduct.amount = amount;
                resultProduct.price = formatMoney(price);
                resultProduct.sum = formatMoney(sumPrice);

                resultProducts.Add(resultProduct);
            }

            dynamic result = new ExpandoObject();
            result.import_id = import.id;
            result.products = resultProducts;
            result.total = formatMoney(total);
            result.created_at = import.created_at;

            return result;
        }


    }

}