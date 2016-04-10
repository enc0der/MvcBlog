using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using MVCBlog.Models.ORM.Entity;

namespace MVCBlog.Models.ORM.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext()
        {
            Database.Connection.ConnectionString = "Server=.\\sqlexpress;Database=MvcBlog;User Id=sa; Password=asdasd;";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<SiteMenu> SiteMenus { get; set; }



    }
}