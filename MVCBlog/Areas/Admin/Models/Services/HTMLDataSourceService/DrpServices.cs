using MVCBlog.Areas.Admin.Models.DTO;
using MVCBlog.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBlog.Models;
using MVCBlog.Models.ORM.Context;

namespace MVCBlog.Areas.Admin.Models.Services.HTMLDataSourceService
{
    public class DrpServices
    {
        public static IEnumerable<SelectListItem> getDrpCategories()
        {

            using (BlogContext db = new BlogContext())
            {
                IEnumerable<SelectListItem> drcategories = db.Categorys.Select(m => new SelectListItem()
                {
                    Text = m.Name,
                    Value = m.ID.ToString()
                }).ToList();

                return drcategories;
            }

          
        }

    }
}