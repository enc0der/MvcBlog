using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class SiteBlogController : Controller
    {
        // GET: SiteBlog
        public ActionResult Index()
        {
            return View();
        }
    }
}