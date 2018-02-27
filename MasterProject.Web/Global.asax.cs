namespace MasterProject.Web
{
    using App_Start;
    using Persistence;
    using Persistence.Migrations;
    using System.Data.Entity;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.Configure();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalContext, Configuration>());
        }
    }
}
