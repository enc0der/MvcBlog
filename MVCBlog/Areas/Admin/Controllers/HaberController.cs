using MVCBlog.Areas.Admin.Models.DTO;
using MVCBlog.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Controllers
{
    public class HaberController : BaseController
    {
        // GET: Admin/Haber
        public ActionResult Index()
        {
            List<HaberVM> model = db.Habers.Where(m => m.IsDeleted == false).OrderByDescending(m => m.ID).Select(m => new HaberVM()
            {

                HaberBaslik =m.HaberBaslik,
                HaberIcerik = m.HaberIcerik,
                Resim=m.HaberIcerik,
                ID=m.ID

            }).ToList();

            return View(model);
        }

        public ActionResult AddHaber()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddHaber(HaberVM model, HttpPostedFileBase HaberResim)
        {

            if(ModelState.IsValid)
            {
                Haber haber = new Haber();
                haber.HaberBaslik = model.HaberBaslik;
                haber.HaberIcerik = model.HaberIcerik;
                haber.Resim = null;

                if(HaberResim != null && HaberResim.ContentLength>0)
                {
                    string ResimAdi = Guid.NewGuid().ToString().Replace("-", "");
                    string uzanti = System.IO.Path.GetExtension(Path.GetFileName(HaberResim.FileName));
                    string TamYol = Path.Combine(Server.MapPath("~/Content/Img/HaberResim/" + ResimAdi + uzanti));

                    haber.Resim = "~/Content/Img/HaberResim/" + ResimAdi + uzanti;


                    HaberResim.SaveAs(TamYol);
                }

                db.Habers.Add(haber);
                db.SaveChanges();
                ViewBag.IslemDurum = 1;
                return RedirectToAction("index");
            }
            else
            {
                ViewBag.IslemDurum = 2;
            }

            return View();
        }

        public ActionResult UpdateHaber(int id)
        {
            Haber haber = db.Habers.FirstOrDefault(m=>m.ID==id);

            HaberVM model = new HaberVM();
            model.HaberBaslik = haber.HaberBaslik;
            model.HaberIcerik = haber.HaberIcerik;
            model.ID = haber.ID;
            model.Resim = haber.Resim;

            return View(model);
        }

        public JsonResult DeleteHaber(int id)
        {

            Haber model = db.Habers.FirstOrDefault(m=>m.ID==id);
            model.IsDeleted = true;
            model.DeleteDate = DateTime.Now;

            db.SaveChanges();

            return Json("");
        }


    }
}