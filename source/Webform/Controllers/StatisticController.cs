using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Webform.Models;

namespace Webform.Controllers
{
    public class StatisticController : BaseController
    {

        public ActionResult Index()
        {
            return RedirectToAction("Revenue", "Statistic");
        }

        public ActionResult Revenue()
        {
            var orderIds = db.Orders
                .Select(o => o.id)
                .ToList();
            var orderProducts = db.OrderProducts
                .Where(op => orderIds.Contains(op.order_id))
                .ToList();
            double revenue = orderProducts.Sum(op => op.amount * op.price);
            double cost = orderProducts.Sum(op => op.amount * op.original_price);
            double profit = revenue - cost;

            ViewBag.revenue = formatMoney(revenue);
            ViewBag.cost = formatMoney(cost);
            ViewBag.profit = formatMoney(profit);

            return View("~/Views/Statistic/Revenue.cshtml");
        }


        public ActionResult Product()
        {
            DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);
            int totalOrder = db.Orders.Count();
            int monthOrder = db.Orders
                .Where(o => o.created_at > oneMonthAgo && o.created_at < DateTime.Now)
                .Count();            
            ViewBag.totalOrder = totalOrder;
            ViewBag.monthOrder = monthOrder;

            return View("~/Views/Statistic/Product.cshtml");
        }


        public ActionResult GetRevenue(string dateRange)
        {
            var orders = db.Orders.Where(o => o.status != 5).OrderBy(o => o.created_at).ToList();
            DateTime[] range = getRange(dateRange);
            int dayDiff = (int)(range[1] - range[0]).TotalDays;
            string format = dayDiff <= 20 ? "dd-MM-yy" : "MM yy";
            var data = orders.Where(o => o.created_at >= range[0] && o.created_at <= range[1])
                .GroupBy(o => o.created_at.ToString(format))
                .Select(g => new { Date = g.Key, Revenue = g.Sum(o => o.product_price) }).ToList();

            double[] revenue = data.Select(d => d.Revenue).ToArray();
            string[] labels = data.Select(d => d.Date).ToArray();
            double max = revenue.Any() ? revenue.Max() * 5 / 4 : 0;
            double step = max / 10;

            return Json(new
            {
                revenue = revenue,
                labels = labels,
                max = max,
                step = step,
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProduct(string dateRange)
        {
            DateTime[] range = getRange(dateRange);
            var startDate = range[0];
            var endDate = range[1];

            var products = db.Products
                .Select(p => new
                {
                    Name = p.name,
                    Sold = p.OrderProducts
                        .Where(op => op.Order.created_at >= startDate && op.Order.created_at <= endDate && op.Order.status != 5)
                        .Sum(op => (int?)op.amount)
                })
                .Where(p => p.Sold != null)
                .OrderByDescending(p => p.Sold)
                .ToList();

            var limit = products.Count(p => p.Sold != 0);
            var topProducts = products
                .Where(p => p.Sold != 0)
                .OrderByDescending(p => p.Sold)
                .Take(limit)
                .ToDictionary(p => p.Name, p => p.Sold);

            var labels = topProducts.Keys.ToArray();
            var data = topProducts.Values.ToArray();

            return Json(new
            {
                data = data,
                labels = labels,
            }, JsonRequestBehavior.AllowGet);
        }

        DateTime[] getRange(string range)
        {
            var split = range.Split(',');
            var start = DateTime.Parse(split[0]);
            var end = DateTime.Parse(split[1]);

            return new DateTime[] { start, end };
        }
    }
}