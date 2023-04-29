using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Webform.Models;

namespace Webform.Controllers
{
    public class HomeController : BaseController
	{
        public HomeController(SoftwareEntities context) : base(context) {}

		[HttpGet("/")]
        public IActionResult Index()
        {
            Admin? authed = Authed();
            if (authed == null)
            {
				return RedirectToAction("Index", "Auth");
			}

            return RedirectToAction("Index", "Order");
        }

    }
}