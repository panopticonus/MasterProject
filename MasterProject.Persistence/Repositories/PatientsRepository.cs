namespace MasterProject.Persistence.Repositories
{
    using Core;
    using Core.Dto;
    using Core.Interfaces.Repositories;
    using Core.Models;
    using System;
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
    }
}
