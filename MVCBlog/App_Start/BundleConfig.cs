using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MVCBlog.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/admin/layout").Include(
                "~/Scripts/bootstrap.min.js",
                "~/jquery.slimscroll.min.js",
                "~/Scripts/fastclick.min.js",
                "~/Scripts/app.min.js",
                "~/Scripts/demo.js"
                ));
        }
    }
}