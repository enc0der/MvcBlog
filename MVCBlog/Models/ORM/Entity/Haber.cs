using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.ORM.Entity
{
    public class Haber:BaseEntity
    {

        [Required]
        public string HaberBaslik { get; set; }

        [Required]
        public string HaberIcerik { get; set; }

        public string Resim { get; set; }

    }
}