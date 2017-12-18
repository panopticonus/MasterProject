namespace MasterProject.Controllers
{
    using System.Web.Mvc;
    using Contracts.HospitalManager;
    using Manager.Languages;

    public class HomeController : Controller
    {
        private readonly IManagerLanguages _managerLanguages;

        public HomeController()
        {
            this._managerLanguages = new LanguagesManager();
        }

        // GET: Home
        public ActionResult Index()
        {
            var countryList = _managerLanguages.GetCountriesList();

            return View();
        }
    }
}