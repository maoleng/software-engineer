using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Webform.Models;
using Webform.Helpers;

namespace Webform.Controllers
{
    public class AuthController : BaseController
	{
		public AuthController(SoftwareEntities context) : base(context) {}

		[HttpGet("/login")]
        public IActionResult Index()
        {
            Admin? authed = Authed();
            if (authed == null)
            {
                return View("~/Views/Login.cshtml");
            }

            return RedirectToAction("Index", "Home");
        }

		[HttpPost("/login")]
        public IActionResult Login(IFormCollection form)
        {
            string email = form["email"];
            string password = form["password"];

            Admin? admin = db.Admin.SingleOrDefault(c => c.email == email);
            if (admin == null)
            {
                return RedirectBackWithMessage("Username or Password is incorrect!");
            }

            bool check = BCrypt.Net.BCrypt.Verify(password, admin.password);
            if (!check)
            {
                return RedirectBackWithMessage("Email or Password is incorrect!");
            }

            session.SetObject("authed", admin);

            return RedirectToAction("Index", "Home");
        }



    }
}