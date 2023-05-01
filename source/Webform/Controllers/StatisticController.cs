using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webform.Models;

namespace Webform.Controllers
{
    public class StatisticController : BaseController
    {

        [HttpGet]
        [Route("/statistic")]
        public ActionResult Index()
        {
            return View("~/Views/Statistic/Index.cshtml");
        }

    }
}