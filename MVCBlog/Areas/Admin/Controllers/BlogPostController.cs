using MVCBlog.Areas.Admin.Models.DTO;
using MVCBlog.Areas.Admin.Models.Services.HTMLDataSourceService;
using MVCBlog.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Controllers
{
    public class BlogPostController : BaseController
    {

        public ActionResult Index()
        {
            List<BlogPostVM> blogpost = db.BlogPost.Where(m => m.IsDeleted == false).OrderByDescending(m => m.ID).Select(m => new BlogPostVM()
            {
                ID = m.ID,
                Title = m.Title,
                CategoryName=m.Category.Name
                
            }).ToList();

            return View(blogpost);
        }
       
        public ActionResult AddBlogPost()
        {
            BlogPostVM model = new BlogPostVM();
            model.drpCategories = DrpServices.getDrpCategories();

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddBlogPost(BlogPostVM model)
        {
            BlogPostVM vmodel = new BlogPostVM();
            vmodel.drpCategories = DrpServices.getDrpCategories();

            if (ModelState.IsValid)
            {
                string filename="";

                foreach (string name in Request.Files)
                {
                    model.PostImage = Request.Files[name];
                    string ext = Path.GetExtension(model.PostImage.FileName);

                    if(ext==".jpg" || ext==".jpeg" || ext==".png")
                    {

                        string uniqnumber = Guid.NewGuid().ToString();
                        filename = uniqnumber + model.PostImage.FileName;
                        model.PostImage.SaveAs(Server.MapPath("~/Content/Img/BlogPostResim/" + filename));
                    }
                    else
                    {
                        ViewBag.hata = "resim formatı uygun degildir.";
                    }
                
                }

                BlogPost blogpost = new BlogPost();
                blogpost.CategoryID = model.CategoryID;
                blogpost.Title = model.Title;
                blogpost.Content = model.Content;
                blogpost.ImagePath = filename;

                db.BlogPost.Add(blogpost);
                db.SaveChanges();
                ViewBag.IslemDurum = 1;
                return View(vmodel);
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View(vmodel);
            }
            
        }

        public JsonResult DeleteBlogPost(int id)
        {

            BlogPost blogpost = db.BlogPost.FirstOrDefault(m => m.ID == id);
            blogpost.IsDeleted = true;
            blogpost.DeleteDate = DateTime.Now;
            db.SaveChanges();
            return Json("");

        }


        public ActionResult UpdateBlogPost(int id)
        {
            BlogPost blogpost = db.BlogPost.FirstOrDefault(m => m.ID == id);

            BlogPostVM model = new BlogPostVM();

            model.CategoryID = blogpost.CategoryID;
            model.Title = blogpost.Title;
            model.Content = blogpost.Content;
            model.drpCategories = DrpServices.getDrpCategories();

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateBlogPost(BlogPostVM model)
        {
            model.drpCategories = DrpServices.getDrpCategories();

            if (ModelState.IsValid)
            {

            BlogPost blogpost = db.BlogPost.FirstOrDefault(m => m.ID == model.ID);
            blogpost.CategoryID = model.CategoryID;
            blogpost.Title = model.Title;
            blogpost.Content = model.Content;
            
            db.SaveChanges();
                ViewBag.IslemDurum = 1;
                return View(model);
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View(model);
            }
           
        }

    }
}