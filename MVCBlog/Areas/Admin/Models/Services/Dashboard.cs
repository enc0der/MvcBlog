using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCBlog.Models.ORM.Context;

namespace MVCBlog.Areas.Admin.Models.Services
{
    public class Dashboard
    {
        BlogContext db = new BlogContext();



        public int GetToplamHaberSayisi()
        {

          return  db.Habers.Where(m=>m.IsDeleted==false).Count();  
        }

        public int GetToplamHizmetSayisi()
        {
            return db.Hizmets.Where(m => m.IsDeleted == false).Count();
        }
    }
}