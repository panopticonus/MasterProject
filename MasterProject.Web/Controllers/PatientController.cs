namespace MasterProject.Web.Controllers
{
    using Core.Dto;
    using Core.Interfaces.Repositories;
    using Models;
    using System;
    using System.Web.Mvc;

    [Authorize]
    public class PatientController : Controller
    {
        private readonly IPatientsRepository _repository;
        private readonly ILanguagesRepository _languagesRepository;

        public PatientController(IPatientsRepository repository, ILanguagesRepository languagesRepository)
        {
            this._repository = repository;
            this._languagesRepository = languagesRepository;
        }

        [Authorize(Roles = "Doctor, Nurse")]
        public ActionResult PatientList()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Doctor, Nurse")]
        public ActionResult PatientListDataTable(FormCollection form)
        {
            var orderColumn = Convert.ToInt32(form["order[0][column]"]);
            var searchFilter = new SearchFilters(form)
            {
                OrderBy = $"{typeof(PatientDto).GetProperties()[orderColumn].Name} {form["order[0][dir]"].ToUpper()}"
            };

            var postRequests = this._repository.GetPatientList(searchFilter);

            return Json(new
            {
                postRequests.iTotalRecords,
                postRequests.iTotalDisplayRecords,
                postRequests.aaData
            });
        }

        [Authorize(Roles = "Nurse")]
        public ActionResult AddPatient()
        {
            var model = new AddPatientViewModel
            {
                Countries = _languagesRepository.GetCountriesList()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Nurse")]
        public JsonResult AddPatient(FormCollection form)
        {
            var patient = new PatientDto
            {
                FirstName = form["firstname"],
                SecondName = form["secondname"],
                Surname = form["surname"],
                Street = form["street"],
                BuildingNumber = form["buildingnumber"],
                FlatNumber = form["flatnumber"],
                ZipCode = form["zipcode"],
                City = form["city"],
                CountryId = Convert.ToInt32(form["Countries"]),
                PhoneNumber = form["phonenumber"],
                DateOfBirth = Convert.ToDateTime(form["dateofbirth"]),
                CityOfBirth = form["cityofbirth"],
                Pesel = form["pesel"],
                NationalityId = Convert.ToInt32(form["nationality"])
            };

            var result = _repository.AddPatient(patient);

//TODO Dodać przekierowanie  
            return Json(new
            {
                type = result > 0 ? "OK" : "Error",
                message = result > 0 ? "Poprawnie dodano pacjenta" : "Wystąpił błąd!"
            });
        }

        [Authorize(Roles = "Doctor, Nurse")]
        public ActionResult EditPatient(int id)
        {
            return View();
        }
    }
}