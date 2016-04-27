using MVCBlog.Areas.Admin.Models.Attributes;
using MVCBlog.Models.ORM.Context;
using MVCBlog.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


/// <summary>
/// Nuh ÇOLAKKADIOĞLU
/// hex-tr@hotmail.com
/// 
/// </summary>
/// 


namespace MVCBlog.Areas.Admin.Controllers
{
    [LoginControl]
    public class HomeController : Controller
    {
        BlogContext db = new BlogContext();

        public ActionResult Index()
        {
            //string email = HttpContext.User.Identity.Name;
            //AdminUser adminUser = db.AdminUsers.FirstOrDefault(m => m.EMail == email);
            //string name = adminUser.Name;
            //string surname = adminUser.Surname;


            return View();
        }
    }
}