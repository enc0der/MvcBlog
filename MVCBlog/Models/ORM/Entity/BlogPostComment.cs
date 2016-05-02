using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.ORM.Entity
{
    public class BlogPostComment:BaseEntity
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsActive { get; set; }

        public int BlogPostID { get; set; }

        [ForeignKey("BlogPostID")]
        public virtual BlogPost BlogPost { get; set; }

        public virtual List<BlogPostComment> BlogPostComments { get; set; }

    }
}