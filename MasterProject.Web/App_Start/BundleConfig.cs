﻿namespace MasterProject.Web.App_Start
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/layout").Include(
                "~/Scripts/jquery-3.3.1.js",
                "~/Scripts/popper.min.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/toastr.min.js",
                "~/Scripts/datatables.min.js"));

            bundles.Add(new StyleBundle("~/Content/layout").Include(
                "~/Content/bootstrap.css",
                "~/Content/dashboard.css",
                "~/Content/toastr.min.css",
                "~/Content/datatables.min.css"));

            bundles.Add(new ScriptBundle("~/Content/login").Include(
                "~/Content/signin.css"));
        }
    }
}