using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Session = Microsoft.AspNetCore.Http.ISession;


namespace Webform.Controllers
{
    abstract public class BaseController : Controller
    {

        protected Session session;

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);
			session = HttpContext.Session;
		}

    
    }
}