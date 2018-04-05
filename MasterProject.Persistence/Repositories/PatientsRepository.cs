namespace MasterProject.Persistence.Repositories
{
    using System;
    using Core;
    using Core.Interfaces.Repositories;
    using Core.Dto;
    using Core.Models;

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
    }
}
