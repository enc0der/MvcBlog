using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Controllers
{
    public class HizmetController : BaseController
    {
        
        public ActionResult Index()
        {
            return View();
        }
    }
}