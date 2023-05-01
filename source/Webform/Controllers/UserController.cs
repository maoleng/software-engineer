﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webform.Models;

namespace Webform.Controllers
{
    public class UserController : BaseController
    {

        [HttpGet]
        [Route("/customer")]
        public ActionResult Index()
        {
            return View("~/Views/User/Index.cshtml");
        }

    }
}