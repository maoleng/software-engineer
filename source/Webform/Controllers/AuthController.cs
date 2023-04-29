using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Webform.Models;
using static System.Collections.Specialized.BitVector32;

namespace Webform.Controllers
{
    public class AuthController : BaseController
    {

        [HttpGet]
        [Route("/login")]
        public ActionResult Index()
        {
            Admin authed = Authed();
            if (authed == null)
            {
                return View("~/Views/Login.cshtml");
            }

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [Route("/login")]
        public ActionResult Login(FormCollection form)
        {
            string email = form["email"];
            string password = form["password"];

            Admin admin = db.Admins.SingleOrDefault(c => c.email == email);

            if (admin == null)
            {
                return RedirectBack("Username or Password is incorrect!");
            }

            bool check = BCrypt.Net.BCrypt.Verify(password, admin.password);
            if (!check)
            {
                return RedirectBack("Email or Password is incorrect!");
            }

            Session["authed"] = admin;

            return RedirectToAction("Index", "Home");
        }

    }
}
