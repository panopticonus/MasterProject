namespace MasterProject.Web.Controllers
{
    using Core.Interfaces.Repositories;
    using Microsoft.AspNet.Identity;
    using System.Web.Mvc;

    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAccountsRepository _accountRepository;

        public HomeController(IAccountsRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var model = _accountRepository.GetUserName(userId);

            return View(model: model);
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