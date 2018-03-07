namespace MasterProject.Web.Controllers
{
    using Core.Interfaces.Managers;
    using Core.Interfaces.Repositories;
    using System.Web.Mvc;
    using Core.Enums;

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILanguagesRepository _languagesRepository;
        private readonly IHomeManager _homeManager;

        public HomeController(ILanguagesRepository languagesRepository, IHomeManager homeManager)
        {
            this._languagesRepository = languagesRepository;
            this._homeManager = homeManager;
        }

        public ActionResult Index()
        {
            var countryList = _languagesRepository.GetCountriesList();

            return View();
        }

        public ActionResult EkgMeasurement()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ReadEkgData()
        {
            return Json(new
            {
                data = _homeManager.GetData((int)DeviceTypes.Ekg)
            });
        }
    }
}