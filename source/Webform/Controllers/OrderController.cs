using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Webform.Models;

namespace Webform.Controllers
{

    public class OrderController : BaseController
	{
        public OrderController(SoftwareEntities context) : base(context) {}

		[HttpGet("/order")]
        public IActionResult Index(int? page)
        {
            Admin? authed = Authed();
            if (authed == null)
            {
				return RedirectToAction("Index", "Auth");
			}

            var orders = db.Order.ToListAsync();
            foreach (var order in orders)
            {
                if (order.name != null)
                {
                    string name = order.name;
                    // Other properties accessed after null check
                }
            }

            ViewBag.orders = orders;

            return View();
        }

    }
}