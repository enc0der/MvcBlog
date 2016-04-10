using MVCBlog.Areas.Admin.Models.DTO;
using MVCBlog.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Controllers
{

    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            List<CategoryVM> model = db.Categorys.Where(m => m.IsDeleted == false).OrderBy(m => m.AddDate).Select(m => new CategoryVM()
            {
                Name = m.Name,
                Description = m.Description,
                ID = m.ID
            }).ToList();

            return View(model);
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryVM model)
        {

            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.Name = model.Name;
                category.Description = model.Description;
                db.Categorys.Add(category);
                db.SaveChanges();
                ViewBag.IslemDurum = 1;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View();
            }

        }

        /// <summary>
        /// kategori silme
        /// </summary>
        /// <param name="id">int değer alır kategori ID</param>
        /// <returns></returns>
        public JsonResult DeleteCategory(int id)
        {

            Category category = db.Categorys.FirstOrDefault(m => m.ID == id);
            category.IsDeleted = true;
            category.DeleteDate = DateTime.Now;
            db.SaveChanges();

            return Json("");

        }


        //UpdateCategory/id
        public ActionResult UpdateCategory(int id)
        {
            Category category = db.Categorys.FirstOrDefault(m => m.ID == id);
            CategoryVM model = new CategoryVM();

            model.Name = category.Name;
            model.Description = category.Description;

            return View(model);

        }


        //UpdateCategory/id
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateCategory(CategoryVM model)
        {

           if(ModelState.IsValid)
            {
                Category category = db.Categorys.FirstOrDefault(m => m.ID == model.ID);

                category.Name = model.Name;
                category.Description = model.Description;

                db.SaveChanges();
                ViewBag.IslemDurum = 1;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View();
            }

        }

    }
}