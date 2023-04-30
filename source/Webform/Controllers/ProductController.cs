using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
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

            var products = builder.OrderBy(o => o.created_at)
                                .ThenByDescending(o => o.created_at)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            ViewBag.Products = products;
            ViewBag.Categories = getCategories();
            ViewBag.Paginate = new Paginate(builder.Count(), pageSize);

            return View("~/Views/Product/Index.cshtml");
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