using System.Data.Common;
using System.Diagnostics;
using System.EnterpriseServices;
using System.Web.Mvc;
using System.Web;

using Webform.Models;



namespace Webform.Controllers
{
    abstract public class BaseController : Controller
    {

        protected SoftwareEngineerEntities db = new SoftwareEngineerEntities();

        protected Admin Authed()
        {
            return Session["authed"] as Admin;
        }

        public ActionResult RedirectBack(string message = "")
        {
            if (message != "")
            {
                TempData["message"] = message;
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}