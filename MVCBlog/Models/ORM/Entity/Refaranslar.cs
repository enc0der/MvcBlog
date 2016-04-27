using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.ORM.Entity
{
    public class Refaranslar:BaseEntity
    {

        [Required]
        [StringLength(50)]
        public string RefaransAdi { get; set; }

        [StringLength(250)]
        public string RefaransResim { get; set; }

        public bool isActive { get; set; }
    }
}