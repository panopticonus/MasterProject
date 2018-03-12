namespace MasterProject.Web.Controllers
{
    using System;
    using Core.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using Models;
    using System.Web;
    using System.Web.Mvc;
    using Core.Dto;
    using Core.Interfaces.Repositories;

    [Authorize]
    public class AccountController : Controller
    {
        public SignInManager<Users, string> SignInManager => HttpContext.GetOwinContext()
            .Get<SignInManager<Users, string>>();

        private readonly IAccountsRepository _repository;

        public AccountController(IAccountsRepository repository)
        {
            this._repository = repository;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var loginStatus = SignInManager.PasswordSignIn(model.UserName, model.Password, model.RememberMe, true);
            if (loginStatus == SignInStatus.Success)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Login", "Account");
        }

        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateAccount(FormCollection form)
        {
            var account = new AccountDto
            {
                Role = Convert.ToInt32(form["role"]),
                Pwz = form["pwz"],
                Name = form["name"],
                Surname = form["surname"],
                UserName = form["userName"],
                Email = form["email"],
                Password = form["password"],
            };

            var result = _repository.CreateAccount(account);

            return Json(new
            {
                type = "OK",
                message = "Poprawnie dodano użytkownika"
            });
        }

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;
    }
}