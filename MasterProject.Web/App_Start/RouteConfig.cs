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
                name: "AddAccountDetails",
                url: "uzupelnij-dane",
                defaults: new { controller = "Account", action = "AddAccountDetails" }
            );

            routes.MapRoute(
                name: "MainPage",
                url: "dashboard",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "ErrorAccessDenied",
                url: "Home/ErrorAccessDenied",
                defaults: new { controller = "Home", action = "ErrorAccessDenied" }
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
                name: "AccountList",
                url: "lista-pracownikow",
                defaults: new { controller = "Account", action = "AccountList" }
            );

            routes.MapRoute(
                name: "AccountListDataTable",
                url: "Account/AccountListDataTable",
                defaults: new { controller = "Account", action = "AccountListDataTable" }
            );

            routes.MapRoute(
                name: "EditAccount",
                url: "edytuj-konto",
                defaults: new { controller = "Account", action = "EditAccount", isActive = "{isActive}", id = "{id}" }
            );

            routes.MapRoute(
                name: "PatientList",
                url: "lista-pacjentow",
                defaults: new { controller = "Patient", action = "PatientList" }
            );

            routes.MapRoute(
                name: "PatientListDataTable",
                url: "Patient/PatientListDataTable",
                defaults: new { controller = "Patient", action = "PatientListDataTable" }
            );

            routes.MapRoute(
                name: "AddPatient",
                url: "dodaj-pacjenta",
                defaults: new { controller = "Patient", action = "AddPatient" }
            );

            routes.MapRoute(
                name: "EditPatient",
                url: "edytuj-pacjenta/{id}",
                defaults: new { controller = "Patient", action = "EditPatient", id = "{id}" }
            );

            routes.MapRoute(
                name: "EditPatientData",
                url: "Patient/EditPatientData",
                defaults: new {controller = "Patient", action = "EditPatientData"}
            );

            routes.MapRoute(
                name: "AddPatientNote",
                url: "dodaj-notatke",
                defaults: new { controller = "Patient", action = "AddNote" }
            );

            routes.MapRoute(
                name: "ReadData",
                url: "Home/ReadData/{deviceTypeId}",
                defaults: new { controller = "Patient", action = "ReadData", deviceTypeId = "{deviceTypeId}" }
            );

            routes.MapRoute(
                name: "EkgMeasurement",
                url: "pomiar-ekg/{id}",
                defaults: new { controller = "Patient", action = "EkgMeasurement", id = "{id}" }
            );

            routes.MapRoute(
                name: "TemperatureMeasurement",
                url: "pomiar-temperatury/{id}",
                defaults: new { controller = "Patient", action = "TemperatureMeasurement", id = "{id}" }
            );

            routes.MapRoute(
                name: "HumidityMeasurement",
                url: "pomiar-wilgotnosci/{id}",
                defaults: new { controller = "Patient", action = "HumidityMeasurement", id = "{id}" }
            );

            routes.MapRoute(
                name: "SaveData",
                url: "zapisz-dane",
                defaults: new { controller = "Patient", action = "SaveData" }
            );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
