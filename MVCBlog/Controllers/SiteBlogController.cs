using MVCBlog.Models.ORM.Entity;
using MVCBlog.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class SiteBlogController : SiteBaseController
    {
        // GET: SiteBlog
        public ActionResult Index(int id)
        {
            BlogPost blogpost = db.BlogPost.FirstOrDefault(m=>m.ID==id);

            BlogPostVM model = new BlogPostVM();

            model.Title = blogpost.Title;
            model.PostImage = blogpost.ImagePath;
            model.Content = blogpost.Content;
            model.Category = blogpost.Category.Name;
            model.AddDate = blogpost.AddDate;
            return View(model);
        }
    }
}