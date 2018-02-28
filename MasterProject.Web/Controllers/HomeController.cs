namespace MasterProject.Web.Controllers
{
    using Core.Interfaces.Repositories;
    using System.Web.Mvc;

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILanguagesRepository _languagesRepository;

        public HomeController(ILanguagesRepository languagesRepository)
        {
            this._languagesRepository = languagesRepository;
        }

        // GET: Home
        public ActionResult Index()
        {
            var countryList = _languagesRepository.GetCountriesList();

            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
    }
}