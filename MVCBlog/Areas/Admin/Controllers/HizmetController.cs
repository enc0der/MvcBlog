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
    public class HizmetController : BaseController
    {
        //

        // hizmet listesi anasayfa
        public ActionResult Index()
        {

            List<HizmetVM> hizmet = db.Hizmets.Where(m => m.IsDeleted == false).OrderByDescending(m => m.ID).Select(m => new HizmetVM()
            {
                HizmetAdi = m.HizmetAdi,
                HizmetIcerik = m.HizmetIcerik,
                HizmetResim=m.HizmetResim,
                HizmetSirasi=m.HizmetSirasi,
                ID=m.ID
            }).ToList();

            return View(hizmet);
        }

        public ActionResult AddHizmet()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddHizmet(HizmetVM model, HttpPostedFileBase HizmetResim)
        {

            if (ModelState.IsValid)
            {

                Hizmet hizmet = new Hizmet();
                hizmet.HizmetAdi = model.HizmetAdi;
                hizmet.HizmetIcerik = model.HizmetIcerik;
                hizmet.HizmetSirasi = model.HizmetSirasi;
                hizmet.HizmetResim = null;


                if (HizmetResim != null && HizmetResim.ContentLength > 0)
                {
                    string ResimAdi = Guid.NewGuid().ToString().Replace("-", "");
                    string uzanti = System.IO.Path.GetExtension(Path.GetFileName(HizmetResim.FileName));
                   string TamYol = Path.Combine(Server.MapPath("~/Content/Img/HizmetResim/" + ResimAdi + uzanti));

                    hizmet.HizmetResim = "~/Content/Img/HizmetResim/" + ResimAdi+ uzanti;


                    HizmetResim.SaveAs(TamYol);
                }


                db.Hizmets.Add(hizmet);
                db.SaveChanges();
                ViewBag.IslemDurum = 1;


                return RedirectToAction("index");

            }else
            {
                ViewBag.IslemDurum = 2;
            }

            return View();
        }


        public JsonResult DeleteHizmet(int id)
        {

            Hizmet hizmet = db.Hizmets.FirstOrDefault(m=>m.ID==id);
            hizmet.IsDeleted = true;
            hizmet.DeleteDate = DateTime.Now;
            db.SaveChanges();

            return Json("");
        }

        public ActionResult UpdateHizmet(int id)
        {

            Hizmet hizmet = db.Hizmets.FirstOrDefault(m=>m.ID==id);

            HizmetVM model = new HizmetVM();

            model.HizmetAdi = hizmet.HizmetAdi;
            model.HizmetIcerik = hizmet.HizmetIcerik;
            model.HizmetSirasi = hizmet.HizmetSirasi;

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateHizmet(HizmetVM model, HttpPostedFileBase HizmetResim)
        {

            if(ModelState.IsValid)
            {
                Hizmet hizmet = db.Hizmets.FirstOrDefault(m => m.ID == model.ID);
                hizmet.HizmetAdi = model.HizmetAdi;
                hizmet.HizmetIcerik = model.HizmetIcerik;
                hizmet.HizmetSirasi = model.HizmetSirasi;
                hizmet.HizmetResim = null;

                if (HizmetResim != null && HizmetResim.ContentLength > 0)
                {
                    string ResimAdi = Guid.NewGuid().ToString().Replace("-", "");
                    string uzanti = System.IO.Path.GetExtension(Path.GetFileName(HizmetResim.FileName));
                    string TamYol = Path.Combine(Server.MapPath("~/Content/Img/HizmetResim/" + ResimAdi + uzanti));

                    hizmet.HizmetResim = "~/Content/Img/HizmetResim/" + ResimAdi + uzanti;


                    HizmetResim.SaveAs(TamYol);
                }



                db.SaveChanges();
                ViewBag.IslemDurum = 1;
                return RedirectToAction("index");
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View(model);
            }

        }


    }
}