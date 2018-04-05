namespace MasterProject.Web.Controllers
{
    using Core.Enums;
    using Core.Interfaces.Managers;
    using System.Web.Mvc;

    [Authorize]
    public class HomeController : Controller
    {
        private readonly IHomeManager _homeManager;

        public HomeController(IHomeManager homeManager)
        {
            this._homeManager = homeManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EkgMeasurement()
        {
            return View();
        }

        public ActionResult ErrorAccessDenied()
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