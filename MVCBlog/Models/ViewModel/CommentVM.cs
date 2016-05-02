using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.ViewModel
{
    public class CommentVM
    {
        [Display(Name ="Başlık")]
        public string Title { get; set; }

        [Display(Name = "İçerik")]
        public string Content { get; set; }

        public int BlogPostId { get; set; }
    }
}