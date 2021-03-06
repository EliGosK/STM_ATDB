using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace STM.ATDB {

    public class BundleConfig {

        public static void RegisterBundles(BundleCollection bundles) {

            var scriptBundle = new ScriptBundle("~/Scripts/bundle");
            var styleBundle = new StyleBundle("~/Content/bundle");

            // jQuery
            scriptBundle
                .Include("~/Scripts/jquery-2.2.4.js");

            // Bootstrap
            scriptBundle
                .Include("~/Scripts/bootstrap.js");

            scriptBundle
                .Include("~/Scripts/sec.imp.js");
            

            // Bootstrap
            styleBundle
                .Include("~/Content/bootstrap.css");

            // FontAwesome
            styleBundle
                .Include("~/Content/fontawesome-all.css");

            // Custom site styles
            styleBundle
                .Include("~/Content/Site.css"
                    , "~/Content/sec.imp.css");

            bundles.Add(scriptBundle);
            bundles.Add(styleBundle);

#if !DEBUG
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}