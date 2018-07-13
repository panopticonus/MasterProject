namespace MasterProject.Persistence.Repositories
{
    using Core;
    using Core.Dto;
    using Core.Interfaces.Repositories;
    using Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;

    public class PatientsRepository : IPatientsRepository
    {
        private readonly IHospitalContext _context;

        public PatientsRepository(IHospitalContext context)
        {
            _context = context;
        }

        public int AddPatient(PatientDto patient)
        {
            try
            {
                var address = new Addresses
                {
                    BuildingNumber = patient.BuildingNumber,
                    City = patient.City,
                    CountryId = patient.CountryId,
                    FlatNumber = patient.FlatNumber,
                    Street = patient.Street,
                    ZipCode = patient.ZipCode
                };

                _context.Addresses.Add(address);
                _context.SaveChanges();

                var newPatient = new Patients
                {
                    AddressId = address.Id,
                    DateOfBirth = patient.DateOfBirth,
                    FirstName = patient.FirstName,
                    SecondName = patient.SecondName,
                    Surname = patient.Surname,
                    PhoneNumber = patient.PhoneNumber,
                    CityOfBirth = patient.CityOfBirth,
                    Pesel = patient.Pesel,
                    NationalityId = patient.NationalityId
                };

                _context.Patients.Add(newPatient);
                _context.SaveChanges();

                return newPatient.Id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public DataTablesObject<PatientDto> GetPatientList(SearchFilters searchFilters)
        {
            var patients = (from patient in _context.Patients
                            select new PatientDto
                            {
                                Id = patient.Id,
                                FirstName = patient.FirstName,
                                Surname = patient.Surname,
                                Pesel = patient.Pesel,
                                City = patient.Address.City,
                                PhoneNumber = patient.PhoneNumber
                            }).ToList();

            var outputList = patients.OrderBy(searchFilters.OrderBy).Skip(searchFilters.DisplayStart)
                .Take(searchFilters.DisplayLength).ToList();

            var postRequests = new DataTablesObject<PatientDto>();
            postRequests.iTotalRecords = postRequests.iTotalDisplayRecords = patients.Count;
            postRequests.aaData = outputList;

            return postRequests;
        }

        public Patients GetPatient(int id)
        {
            return _context.Patients.Single(x => x.Id == id);
        }

        public bool EditPatient(PatientDto patient)
        {
            try
            {
                var oldPatient = _context.Patients.Single(x => x.Id == patient.Id);

                oldPatient.Address.BuildingNumber = patient.BuildingNumber;
                oldPatient.Address.FlatNumber = patient.FlatNumber;
                oldPatient.Address.City = patient.City;
                oldPatient.Address.CountryId = patient.CountryId;
                oldPatient.Address.Street = patient.Street;
                oldPatient.Address.ZipCode = patient.ZipCode;
                oldPatient.CityOfBirth = patient.CityOfBirth;
                oldPatient.DateOfBirth = patient.DateOfBirth;
                oldPatient.FirstName = patient.FirstName;
                oldPatient.NationalityId = patient.NationalityId;
                oldPatient.Pesel = patient.Pesel;
                oldPatient.PhoneNumber = patient.PhoneNumber;
                oldPatient.SecondName = patient.SecondName;
                oldPatient.Surname = patient.Surname;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void AddNote(string content, int patientId, string userId)
        {
            var patientNote = new PatientNotes
            {
                Content = content,
                CreateDateTime = DateTime.Now,
                PatientId = patientId,
                UserId = userId
            };

            _context.PatientNotes.Add(patientNote);
            _context.SaveChanges();
        }

        public List<PatientNotesDto> GetPatientNotes(int id)
        {
            var patientNotes = (from notes in _context.PatientNotes
                                where notes.PatientId == id
                                select new PatientNotesDto
                                {
                                    Content = notes.Content,
                                    CreateDateTime = notes.CreateDateTime,
                                    UserName = notes.User.FirstName + " " + notes.User.LastName
                                }).ToList();

            return patientNotes;
        }
    }
}
