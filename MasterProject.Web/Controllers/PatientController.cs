﻿namespace MasterProject.Web.Controllers
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

            var patientId = _repository.AddPatient(patient);

            return Json(new
            {
                type = patientId > 0 ? "OK" : "Error",
                message = patientId > 0 ? "Poprawnie dodano pacjenta" : "Wystąpił błąd!",
                url = $"edytuj-pacjenta/{patientId}"
            });
        }

        [Authorize(Roles = "Doctor, Nurse")]
        public ActionResult EditPatient(int id)
        {
            var patient = this._repository.GetPatient(id);

            var countryList = _languagesRepository.GetCountriesList();

            var model = new EditPatientViewModel
            {
                Nationalities = countryList,
                Countries = countryList,
                BuildingNumber = patient.Address.BuildingNumber,
                City = patient.Address.City,
                CityOfBirth = patient.CityOfBirth,
                DateOfBirth = patient.DateOfBirth,
                FirstName = patient.FirstName,
                FlatNumber = patient.Address.FlatNumber,
                Pesel = patient.Pesel,
                PhoneNumber = patient.PhoneNumber,
                SecondName = patient.SecondName,
                Street = patient.Address.Street,
                Surname = patient.Surname,
                ZipCode = patient.Address.ZipCode,
                Id = patient.Id,
                CountryName = patient.Address.Country.Name,
                NationalityName = patient.Nationality.Name,
                CountryId = patient.Address.CountryId,
                NationalityId = patient.NationalityId
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Nurse")]
        public ActionResult EditPatientData(FormCollection form)
        {
            var patient = new PatientDto
            {
                Id = Convert.ToInt32(form["Id"]),
                FirstName = form["FirstName"],
                SecondName = form["SecondName"],
                Surname = form["Surname"],
                Street = form["Street"],
                BuildingNumber = form["BuildingNumber"],
                FlatNumber = form["FlatNumber"],
                ZipCode = form["ZipCode"],
                City = form["City"],
                CountryId = Convert.ToInt32(form["CountryId"]),
                PhoneNumber = form["PhoneNumber"],
                DateOfBirth = Convert.ToDateTime(form["DateOfBirth"]),
                CityOfBirth = form["CityOfBirth"],
                Pesel = form["Pesel"],
                NationalityId = Convert.ToInt32(form["NationalityId"])
            };

            var result = _repository.EditPatient(patient);

            return Json(new
            {
                type = result ? "OK" : "Error",
                message = result ? "Poprawnie zapisano dane pacjenta" : "Wystąpił błąd!"
            });
        }
    }
}