using MVCBlog.Areas.Admin.Models.DTO;
using MVCBlog.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Controllers
{
    public class BlogPostController : BaseController
    {
       
        public ActionResult AddBlogPost()
        {
            BlogPostVM model = new BlogPostVM();
             model.drpCategories = db.Categorys.Select(m => new SelectListItem() {
                Text = m.Name,
                Value = m.ID.ToString()
            }).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddBlogPost(BlogPostVM model)
        {
    
            if (ModelState.IsValid)
            {
                BlogPost blogpost = new BlogPost();
                blogpost.CategoryID = model.CategoryID;
                blogpost.Title = model.Title;
                blogpost.Content = model.Content;

                db.BlogPost.Add(blogpost);
                db.SaveChanges();
                ViewBag.IslemDurumu = 1;
                return View();
            }
            else
            {
                ViewBag.IslemDurumu = 2;
                return View();
            }
            
        }
    }
}