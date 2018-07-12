namespace MasterProject.Web
{
    using App_Start;
    using Persistence;
    using Persistence.Migrations;
    using Persistence.Repositories;
    using System;
    using System.Data.Entity;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.Configure();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalContext, Configuration>());
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            try
            {
                new ErrorLogsRepository(new HospitalContext()).LogError(exception);
            }
            catch (Exception)
            {
            }
        }
    }
}
