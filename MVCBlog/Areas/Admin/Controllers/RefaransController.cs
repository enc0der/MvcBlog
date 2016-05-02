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
    public class RefaransController : BaseController
    {
        // GET: Admin/Refarans
        public ActionResult Index()
        {
            List<RefaransVM> model = db.Refarans.Where(m => m.IsDeleted == false).OrderByDescending(m => m.ID).Select(m => new RefaransVM()
            {
                ID = m.ID,
                isActive = m.isActive,
                RefaransAdi = m.RefaransAdi,
                RefaransResim = m.RefaransResim
            }).ToList();

            return View(model);
        }

        public ActionResult AddRefarans()
        {
            RefaransVM model = new RefaransVM();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRefarans(RefaransVM model, HttpPostedFileBase RefaransResim)
        {
            //kendime not. resimlerin uzantılarını kontorl et ve boyutlandırma yap gabala yazma :)

            if (ModelState.IsValid)
            {
                Refaranslar refarans = new Refaranslar();

                refarans.RefaransAdi = model.RefaransAdi;
                refarans.RefaransResim = null;
                refarans.isActive = model.isActive;

                if (RefaransResim != null && RefaransResim.ContentLength > 0)
                {
                    string ResimAdi = Guid.NewGuid().ToString().Replace("-", "");
                    string uzanti = System.IO.Path.GetExtension(Path.GetFileName(RefaransResim.FileName));
                    string TamYol = Path.Combine(Server.MapPath("/Content/Img/RefransResim/" + ResimAdi + uzanti));

                    refarans.RefaransResim = "/Content/Img/RefransResim/" + ResimAdi + uzanti;


                    RefaransResim.SaveAs(TamYol);
                }
                db.Refarans.Add(refarans);
                db.SaveChanges();
                return RedirectToAction("index");

            }
            else

            {
                ViewBag.IslemDurum = 2;
            }

            return View();
        }

        public ActionResult UpdateRefarans(int id)
        {
            Refaranslar refarans = db.Refarans.FirstOrDefault(m=>m.ID==id);

            RefaransVM model = new RefaransVM();

            model.ID = refarans.ID;
            model.isActive = refarans.isActive;
            model.RefaransAdi = refarans.RefaransAdi;
            model.RefaransResim = refarans.RefaransResim;
            return View(model);
        }



    }
}