using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Areas.Admin.Models.DTO
{
    public class CategoryVM:BaseVM
    {
        [Required(ErrorMessage ="Kategori ismi giriniz")]
        [Display(Name="Kategori Adı")]
        public string Name { get; set; }

        [Display(Name = "Kategori Açıklama")]
        public string Description { get; set; }

    }
}