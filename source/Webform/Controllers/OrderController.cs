using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class OrderController : BaseController
    {

        [HttpGet]
        [Route("/order")]
        public ActionResult Index(string status, string ordered_at, string q, int page = 1)
        {
            //if (Authed() == null) return RedirectToAction("Index", "Home");

            int pageSize = 20;

            var builder = db.Orders.AsQueryable();
            if (!string.IsNullOrEmpty(status))
            {
                builder = builder.Where(o => o.status.ToString().Equals(status));
            }
            if (!string.IsNullOrEmpty(ordered_at))
            {
                var split = ordered_at.Split(',');
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
                    o.address.Contains(q) ||
                    o.email.Contains(q) ||
                    o.phone.Contains(q) ||
                    o.ship_fee.ToString().Contains(q) ||
                    o.product_price.ToString().Contains(q) ||
                    o.created_at.ToString().Contains(q)
                );
            }

            var orders = builder.Include(o => o.User)
                                .OrderBy(o => o.status)
                                .ThenByDescending(o => o.created_at)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            ViewBag.Orders = orders;
            ViewBag.Paginate = new Paginate(builder.Count(), pageSize);

            return View("~/Views/Order/Index.cshtml");
        }


        [HttpPost]
        [Route("/Order/Update")]
        public ActionResult Update(FormCollection formCollection)
        {
            var order_id = int.Parse(formCollection["order_id"]);
            var update_data = new Dictionary<string, object>();
            var message = "";

            if (bool.TryParse(formCollection["is_paid"], out bool is_paid))
            {
                update_data["is_paid"] = is_paid;
                message = "Update payment status successfully";
            }

            if (int.TryParse(formCollection["status"], out int status))
            {
                if (status == 4)
                {
                    update_data["is_paid"] = true;
                }

                update_data["status"] = status;
                message = "Update status successfully";
            }

            var order = db.Orders.FirstOrDefault(o => o.id == order_id);
            if (order != null)
            {
                foreach (var kvp in update_data)
                {
                    var prop = order.GetType().GetProperty(kvp.Key);
                    if (prop != null)
                    {
                        prop.SetValue(order, kvp.Value);
                    }
                }
                db.SaveChanges();
            }

            TempData["success"] = message;

            return new EmptyResult();
        }


        [HttpGet]
        [Route("/Order/Show")]
        public ActionResult Show(int? order_id)
        {
            var model = getOrderDetail(order_id, true);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("/Order/Print")]
        public ActionResult Print(int? order_id)
        {
            ViewBag.order = getOrderDetail(order_id);

            return View("~/Views/Order/Print.cshtml");
        }



        private object getOrderDetail(int? order_id, bool isJson = false)
        {
            var order = db.Orders
                          .Include(o => o.OrderProducts.Select(op => op.Product))
                          .Include(o => o.Admin)
                          .FirstOrDefault(o => o.id == order_id);

            if (order == null)
            {
                return HttpNotFound();
            }

            List<object> products = new List<object>();
            double productPrice = 0;
            double discountPrice = 0;
            foreach (var orderProduct in order.OrderProducts)
            {
                var discount = orderProduct.discount_price; // discount on each product
                var price = orderProduct.price;
                var amount = orderProduct.amount;
                var sumDiscount = discount * amount;
                var sumPrice = price * amount;

                products.Add(new
                {
                    name = orderProduct.name,
                    amount = amount,
                    price = formatMoney(price),
                    discount = formatMoney(discount),
                    sum = formatMoney(sumPrice - sumDiscount)
                });
                productPrice += sumPrice;
                discountPrice += sumDiscount;
            }
            var ship = order.ship_price;
            var total = productPrice - discountPrice + ship;


            if (isJson)
            {
                var fee = new
                {
                    product_price = formatMoney(productPrice),
                    discount_price = formatMoney(discountPrice),
                    ship = formatMoney(ship),
                    total = formatMoney(total)
                };

                var user = new
                {
                    name = order.name,
                    address = order.address,
                    phone = order.phone,
                    email = order.email
                };

                var model = new
                {
                    order_id = order.id,
                    products = products,
                    fee = fee,
                    user = user,
                    created_at = order.created_at,
                    sales = order.Admin?.name,
                    status = order.status,
                    is_paid = order.is_paid
                };

                return model;
            }


            List<ExpandoObject> resultProducts = new List<ExpandoObject>();
            foreach (var orderProduct in order.OrderProducts)
            {
                var discount = orderProduct.discount_price; // discount on each product
                var price = orderProduct.price;
                var amount = orderProduct.amount;
                var sumDiscount = discount * amount;
                var sumPrice = price * amount;

                dynamic resultProduct = new ExpandoObject();
                resultProduct.name = orderProduct.name;
                resultProduct.amount = amount;
                resultProduct.price = formatMoney(price);
                resultProduct.discount = formatMoney(discount);
                resultProduct.sum = formatMoney(sumPrice - sumDiscount);

                resultProducts.Add(resultProduct);
            }

            dynamic resultFee = new ExpandoObject();
            resultFee.product_price = formatMoney(productPrice);
            resultFee.discount_price = formatMoney(discountPrice);
            resultFee.ship = formatMoney(ship);
            resultFee.total = formatMoney(total);

            dynamic resultUser = new ExpandoObject();
            resultUser.name = order.name;
            resultUser.address = order.address;
            resultUser.phone = order.phone;
            resultUser.email = order.email;

            dynamic result = new ExpandoObject();
            result.order_id = order.id;
            result.products = resultProducts;
            result.fee = resultFee;
            result.user = resultUser;
            result.created_at = order.created_at;
            result.sales = order.Admin?.name;
            result.status = order.status;
            result.is_paid = order.is_paid;

            return result;
        }


    }

}