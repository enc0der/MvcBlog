using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.ORM.Entity
{
    public class Hizmet:BaseEntity
    {

        public string HizmetAdi { get; set; }

        public string HizmetIcerik { get; set; }

        public string HizmetResim { get; set; }

        public int HizmetSirasi { get; set; }
    }
}