using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;
using System.Diagnostics;
using Webform.Helpers;
using Webform.Models;
using Session = Microsoft.AspNetCore.Http.ISession;


namespace Webform.Controllers
{
    abstract public class BaseController : Controller
    {
		protected Session session;
		public SoftwareEntities db;

		protected BaseController(SoftwareEntities context)
		{
			db = context;
		}

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);
			session = HttpContext.Session;
		}

		protected Admin? Authed()
		{
			return session.GetObject<Admin>("authed") ?? null;
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public IActionResult RedirectBackWithMessage(string message)
		{
            TempData["message"] = message;

            return this.RedirectBack();
        }
    }
}