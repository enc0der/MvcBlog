using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCBlog.Models.ORM.Context;

namespace MVCBlog.Areas.Admin.Models.Services
{
    public class Dashboard
    {
        private int ToplamHaberSayisi { get; set ; }

        public int GetToplamHaberSayisi()
        {
            BlogContext db = new BlogContext();
            ToplamHaberSayisi = db.Habers.Count();
            return ToplamHaberSayisi;
        }
    }
}