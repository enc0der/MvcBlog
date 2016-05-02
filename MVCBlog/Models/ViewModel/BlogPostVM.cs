using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.ViewModel
{
    public class BlogPostVM
    {
        public string Title { get; set; }

        public string PostImage { get; set; }

        public string Category { get; set; }

        public DateTime? AddDate { get; set; }

        public string Content { get; set; }

    }
}