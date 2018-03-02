namespace MasterProject.Web.Controllers
{
    using Core.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using Models;
    using System.Web;
    using System.Web.Mvc;

    [Authorize]
    public class AccountController : Controller
    {
        public SignInManager<Users, string> SignInManager => HttpContext.GetOwinContext()
            .Get<SignInManager<Users, string>>();

        [AllowAnonymous]
        public ActionResult Login()
        {
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

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;
    }
}