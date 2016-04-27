using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Areas.Admin.Models.DTO
{
    public class HaberVM:BaseVM
    {

        [Required(ErrorMessage ="zorunlu alan")]
        public string HaberBaslik { get; set; }

        [Required(ErrorMessage = "zorunlu alan")]
        public string HaberIcerik { get; set; }

        public string Resim { get; set; }

    }
}