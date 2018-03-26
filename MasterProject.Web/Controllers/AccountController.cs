namespace MasterProject.Web.Controllers
{
    using Core.Dto;
    using Core.Interfaces.Repositories;
    using Core.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using Models;
    using System;
    using System.Web;
    using System.Web.Mvc;
    using Enums = Core.Enums;

    [Authorize]
    public class AccountController : Controller
    {
        public SignInManager<Users, string> SignInManager => HttpContext.GetOwinContext()
            .Get<SignInManager<Users, string>>();
        public UserManager<Users> UserManager => HttpContext.GetOwinContext()
            .Get<UserManager<Users>>();

        private readonly IAccountsRepository _repository;
        private readonly ILanguagesRepository _languagesRepository;
        private readonly IWardsRepository _wardsRepository;
        private readonly ISpecialtiesRepository _specialtiesRepository;

        public AccountController(ILanguagesRepository languagesRepository, IAccountsRepository repository, IWardsRepository wardsRepository, ISpecialtiesRepository specialtiesRepository)
        {
            this._languagesRepository = languagesRepository;
            this._repository = repository;
            this._wardsRepository = wardsRepository;
            this._specialtiesRepository = specialtiesRepository;
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
                var userId = UserManager.FindByName(model.UserName)?.Id;
                var roleId = _repository.GetUserRole(userId);
                return !_repository.CheckUserDataComplete(userId) && roleId != (int)Enums.Roles.Admin ? RedirectToAction("AddAccountDetails") : RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult AddAccountDetails()
        {
            var userId = User.Identity.GetUserId();

            var model = new AddAccountDetailsViewModel
            {
                Countries = _languagesRepository.GetCountriesList(),
                RoleId = _repository.GetUserRole(userId),
                UserId = userId,
                Wards = _wardsRepository.GetWardList(),
                Specialties = _specialtiesRepository.GetSpecialtyList()
            };

            return View(model);
        }

        [HttpPost]
        public JsonResult AddAccountDetails(FormCollection form)
        {
            var account = new AccountDto
            {
                Street = form["street"],
                BuildingNumber = form["buildingnumber"],
                FlatNumber = form["flatnumber"],
                ZipCode = form["zipcode"],
                City = form["city"],
                CountryId = Convert.ToInt32(form["Countries"]),
                PhoneNumber = form["phonenumber"],
                RoleId = Convert.ToInt32(form["RoleId"]),
                UserId = form["UserId"],
                DateOfBirth = Convert.ToDateTime(form["dateofbirth"]),
                WardId = Convert.ToInt32(form["Wards"]),
                Degree = form["degree"],
                Pwz = form["pwz"],
                SpecialtyId = Convert.ToInt32(form["Specialties"]),
                DegreeOfSpecialty = Convert.ToInt32(form["degreeofspecialty"])
            };

            var result = _repository.AddAccountDetails(account);

            return Json(new
            {
                type = result ? "OK" : "Error",
                message = result ? "Poprawnie uzupełniono dane" : "Wystąpił błąd!"
            });
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
                Name = form["name"],
                Surname = form["surname"],
                UserName = form["userName"],
                Email = form["email"],
                Password = form["password"],
            };

            var result = _repository.CreateAccount(account);

            return Json(new
            {
                type = result ? "OK" : "Error",
                message = result ? "Poprawnie dodano użytkownika" : "Wystąpił błąd!"
            });
        }

        public ActionResult AccountList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AccountListDataTable(FormCollection form)
        {
            var orderColumn = Convert.ToInt32(form["order[0][column]"]);
            var searchFilter = new SearchFilters(form)
            {
                OrderBy = $"{typeof(AccountDto).GetProperties()[orderColumn].Name} {form["order[0][dir]"].ToUpper()}"
            };

            var postRequests = this._repository.GetAccountList(searchFilter);

            return Json(new
            {
                postRequests.iTotalRecords,
                postRequests.iTotalDisplayRecords,
                postRequests.aaData
            });
        }

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;
    }
}