using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webform.Models;

namespace Webform.Controllers
{
    public class AdminController : BaseController
    {


        [HttpGet]
        [Route("/hrm")]
        public ActionResult Index()
        {
            return View("~/Views/Admin/Index.cshtml");
        }

    }
}