using System;
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
        public ActionResult Index(string created_at, string q, int page = 1)
        {
            int pageSize = 20;

            var builder = db.Users.AsQueryable();
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
                    o.phone.Contains(q) ||
                    o.email.Contains(q) ||
                    o.address.ToString().Contains(q) ||
                    o.created_at.ToString().Contains(q)
                );
            }
            var users = builder.OrderByDescending(o => o.created_at)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            ViewBag.Users = users;
            ViewBag.Paginate = new Paginate(builder.Count(), pageSize);

            return View("~/Views/User/Index.cshtml");
        }


        [HttpPost]
        [Route("/customer")]
        public ActionResult Store(FormCollection data)
        {
            if (string.IsNullOrEmpty(data["name"]) || string.IsNullOrEmpty(data["email"]) ||
                string.IsNullOrEmpty(data["phone"]) || string.IsNullOrEmpty(data["address"]))
            {
                TempData["error"] = "Field must not be empty";

                return RedirectBack();
            }

            db.Users.Add(new User()
            {
                name = data["name"],
                email = data["email"],
                phone = data["phone"],
                address = data["address"],
                is_agent = true,
                active = true,
                password = BCrypt.Net.BCrypt.HashPassword(data["email"]),
                created_at = DateTime.Now,
            });
            db.SaveChanges();
            TempData["success"] = "Create agent successfully";

            return RedirectBack();
        }


        [HttpPost]
        [Route("/customer")]
        public ActionResult Cancel(int id)
        {
            User user = db.Users.Find(id);
            if (! user.is_agent)
            {
                TempData["error"] = "Can not handle on normal customer";

                return RedirectBack();
            }
            user.active = !user.active;
            db.SaveChanges();

            TempData["success"] = user.active ? "Locked successfully" : "Unlock successfully";

            return RedirectBack();
        }

        [HttpPost]
        [Route("/customer")]
        public ActionResult Reset(int id)
        {
            User user = db.Users.Find(id);
            if (! user.is_agent)
            {
                TempData["error"] = "Can not handle on normal customer";

                return RedirectBack();
            }
            user.password = BCrypt.Net.BCrypt.HashPassword(user.email);
            db.SaveChanges();

            TempData["success"] = "Password reset successfully";

            return RedirectBack();
        }
    }
}