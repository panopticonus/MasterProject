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
                defaults: new { controller = "Account", action = "Login" }
            );

            routes.MapRoute(
                name: "MainPage",
                url: "dashboard",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "ReadData",
                url: "Home/ReadData",
                defaults: new { controller = "Home", action = "ReadData" }
            );

            routes.MapRoute(
                name: "EkgMeasurement",
                url: "pomiar-ekg",
                defaults: new { controller = "Home", action = "EkgMeasurement" }
            );

            routes.MapRoute(
                name: "Logout",
                url: "wylogowanie",
                defaults: new { controller = "Account", action = "Logout" }
            );

            routes.MapRoute(
                name: "CreateAccount",
                url: "utworz-konto",
                defaults: new { controller = "Account", action = "CreateAccount" }
            );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
