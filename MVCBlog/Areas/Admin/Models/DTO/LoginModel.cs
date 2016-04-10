using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Areas.Admin.Models.DTO
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Bu alan boş geçilemez!")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli bir email adresi giriniz!")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public string Password { get; set; }
    }
}