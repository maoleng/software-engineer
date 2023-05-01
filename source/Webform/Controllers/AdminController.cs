using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI;
using Webform.Models;

namespace Webform.Controllers
{
    public class AdminController : BaseController
    {


        [HttpGet]
        [Route("/hrm")]
        public ActionResult Index(string created_at, string q, int page = 1)
        {
            int pageSize = 20;

            var builder = db.Admins.AsQueryable();
            if (!string.IsNullOrEmpty(created_at))
            {
                var split = created_at.Split(',');
                if (split.Length == 2)
                {
                    var start = DateTime.Parse(split[0]);
                    var end = DateTime.Parse(split[1]);
                    builder = builder.Where(o => o.created_at >= start && o.created_at <= end);
                }
            }
            if (!string.IsNullOrEmpty(q))
            {
                builder = builder.Where(o =>
                    o.name.Contains(q) ||
                    o.email.ToString().Contains(q) ||
                    o.created_at.ToString().Contains(q)
                );
            }
            var admins = builder.OrderByDescending(o => o.created_at)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            ViewBag.Admins = admins;
            ViewBag.Paginate = new Paginate(builder.Count(), pageSize);

            return View("~/Views/Admin/Index.cshtml");
        }
        

        [HttpPost]
        [Route("/hrm")]
        public ActionResult Store(FormCollection data)
        {
            if (string.IsNullOrEmpty(data["name"]) || string.IsNullOrEmpty(data["email"]))
            {
                TempData["error"] = "Field must not be empty";

                return RedirectBack();
            }

            db.Admins.Add(new Admin()
            {
                name = data["name"],
                email = data["email"],
                password = BCrypt.Net.BCrypt.HashPassword(data["email"]),
                is_admin_master = false,
                created_at = DateTime.Now,
            });
            db.SaveChanges();
            TempData["success"] = "Create accountant successfully";

            return RedirectBack();
        }


        [HttpPost]
        [Route("/hrm")]
        public ActionResult Cancel(int id)
        {
            Admin admin = db.Admins.Find(id);
            if (admin.is_admin_master)
            {
                TempData["error"] = "Can not handle on admin master";

                return RedirectBack();
            }
            admin.active = !admin.active;
            db.SaveChanges();

            TempData["success"] = admin.active ? "Locked successfully" : "Unlock successfully";

            return RedirectBack();
        }

        [HttpPost]
        [Route("/hrm")]
        public ActionResult Reset(int id)
        {
            Admin admin = db.Admins.Find(id);
            if (admin.is_admin_master)
            {
                TempData["error"] = "Can not handle on admin master";

                return RedirectBack();
            }
            admin.password = BCrypt.Net.BCrypt.HashPassword(admin.email);
            db.SaveChanges();

            TempData["success"] = "Password reset successfully";

            return RedirectBack();
        }

    }
}