using System.Data.Common;
using System.Diagnostics;
using System.EnterpriseServices;
using System.Web.Mvc;
using System.Web;

using Webform.Models;
using System.Collections.Generic;
using System;
using System.Drawing.Printing;
using System.Globalization;

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

        public string formatMoney(double money)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

            return double.Parse(money.ToString()).ToString("#,###", cul.NumberFormat);
        }

    }
    public class Paginate
    {
        public int totalRecords;
        public int currentPage;
        public int totalPages;
        public int pageSize;

        public Paginate(int totalRecords, int pageSize)
        {
            currentPage = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
            this.totalRecords = totalRecords;
            this.pageSize = pageSize;
            totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
        }

        public bool hasPages()
        {
            return totalPages > 1;
        }

        public bool onFirstPage()
        {
            return currentPage == 1;
        }

        public string previousPageUrl()
        {
            return $"?page={currentPage - 1}";
        }

        public string nextPageUrl()
        {
            return $"?page={currentPage + 1}";
        }

        public bool hasMorePages()
        {
            return totalPages - currentPage != 0;
        }




    }

}