using Microsoft.AspNetCore.Mvc;

namespace Webform.Helpers
{
    public static class RedirectExtension
    {
        public static IActionResult RedirectBack(this Controller controller)
        {
            if (controller.HttpContext.Request.Headers["Referer"].ToString() != "")
            {
                return controller.Redirect(controller.HttpContext.Request.Headers["Referer"].ToString());
            }
            else
            {
                return controller.RedirectToAction("Index", "Home");
            }
        }
    }


}

