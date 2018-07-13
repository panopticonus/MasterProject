namespace MasterProject.Web.Controllers
{
    using System.Web.Mvc;

    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ErrorAccessDenied()
        {
            return View();
        }

        public ActionResult GetPdf(string fileName)
        {
            return File(fileName, "application/pdf");
        }
    }
}