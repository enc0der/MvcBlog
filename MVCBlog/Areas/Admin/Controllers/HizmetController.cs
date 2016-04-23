using MVCBlog.Areas.Admin.Models.DTO;
using MVCBlog.Models.ORM.Entity;
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
    }
}