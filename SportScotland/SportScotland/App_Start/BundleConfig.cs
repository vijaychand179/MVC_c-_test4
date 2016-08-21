using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SportScotland
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.min.js"));

            bundles.Add(new StyleBundle("~/Content/Bootstrap/css").Include(
                        "~/Content/Bootstrap/Css/bootstrap.min.css",
                        "~/Content/Bootstrap/Css/bootstrap-theme.min.css"));
        }
    }
}