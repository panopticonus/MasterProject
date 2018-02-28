namespace MasterProject.Web.App_Start
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/popper.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap.css",
                "~/Content/dashboard.css"));

            bundles.Add(new ScriptBundle("~/Content/login").Include(
                "~/Content/signin.css"));
        }
    }
}