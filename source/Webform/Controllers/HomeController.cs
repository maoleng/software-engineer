using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webform.Models;

namespace Webform.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult Index()
        {
            Admin authed = Authed();
            if (authed == null)
            {
                return View("~/Views/Login.cshtml");
            }

            return RedirectToAction("Index", "Order");
        }

    }
}