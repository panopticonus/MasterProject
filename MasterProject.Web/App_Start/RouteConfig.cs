namespace MasterProject.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Login",
                url: "logowanie",
                defaults: new { controller = "Home", action = "Login" }
            );

            routes.MapRoute(
                name: "MainPage",
                url: "dashboard",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
