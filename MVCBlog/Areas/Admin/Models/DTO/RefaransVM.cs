using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Areas.Admin.Models.DTO
{
    public class RefaransVM:BaseVM
    {
        [Required]
        [Display(Name ="Refans Adı")]
        public string RefaransAdi { get; set; }

        [Display(Name = "Refans Resim")]
        public string RefaransResim { get; set; }

        public bool isActive { get; set; }

    }
}