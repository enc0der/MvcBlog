using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Areas.Admin.Models.DTO
{
    public class HizmetVM : BaseVM
    {
        [Required(ErrorMessage ="zorunlu alan")]
        [Display(Name ="Hizmet Adı")]
        public string HizmetAdi { get; set; }

        [Required(ErrorMessage = "zorunlu alan")]
        [Display(Name = "Hizmet İçerik")]
        public string HizmetIcerik { get; set; }

        [Display(Name = "Hizmet Resmi")]
        public string HizmetResim { get; set; }

        [Display(Name = "Hizmet sırası")]
        public int HizmetSirasi { get; set; }

    }
}