namespace MasterProject.Persistence.Repositories
{
    using Core;
    using Core.Dto;
    using Core.ExtensionMethods;
    using Core.Interfaces.Repositories;
    using Core.Models;
    using KellermanSoftware.CompareNetObjects;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Text;

    public class PatientsRepository : IPatientsRepository
    {
        private readonly IHospitalContext _context;
        private readonly IErrorLogsRepository _errorLogsRepository;

        public PatientsRepository(IHospitalContext context, IErrorLogsRepository errorLogsRepository)
        {
            _context = context;
            _errorLogsRepository = errorLogsRepository;
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
                _errorLogsRepository.LogError(ex);
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

        public bool EditPatient(PatientDto patientDto, string userId)
        {
            try
            {
                var context = new HospitalContext();
                var userManager = new UserManager<Users>(new UserStore<Users>(context));

                var user = userManager.FindById(userId);
                var userName = $"{user.FirstName} {user.LastName}";
                var patient = context.Patients.Single(x => x.Id == patientDto.Id);
                var oldAddress = MyExtentions.DeepClone(patient.Address);
                var oldPatient = MyExtentions.DeepClone(patient);

                patient.Address.BuildingNumber = patientDto.BuildingNumber;
                patient.Address.FlatNumber = patientDto.FlatNumber;
                patient.Address.City = patientDto.City;
                patient.Address.CountryId = patientDto.CountryId;
                patient.Address.Street = patientDto.Street;
                patient.Address.ZipCode = patientDto.ZipCode;
                patient.CityOfBirth = patientDto.CityOfBirth;
                patient.DateOfBirth = patientDto.DateOfBirth;
                patient.FirstName = patientDto.FirstName;
                patient.NationalityId = patientDto.NationalityId;
                patient.Pesel = patientDto.Pesel;
                patient.PhoneNumber = patientDto.PhoneNumber;
                patient.SecondName = patientDto.SecondName;
                patient.Surname = patientDto.Surname;

                var address = MyExtentions.DeepClone(patient.Address);
                var addressLogs = LogAddressChanges(oldAddress, address);
                var logs = LogPatientChanges(oldPatient, patient, userName);
                logs.Content += addressLogs;

                context.PatientLogs.Add(logs);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _errorLogsRepository.LogError(ex);
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

        public void AddDocument(string fileName, int patientId, string userId)
        {
            var patientDocument = new PatientDocuments
            {
                AdditionDateTime = DateTime.Now,
                FileName = fileName,
                PatientId = patientId,
                UserId = userId
            };

            _context.PatientDocuments.Add(patientDocument);
            _context.SaveChanges();
        }

        private static string LogAddressChanges(Addresses oldAddress, Addresses address)
        {
            var propertyCount = typeof(Addresses).GetProperties().Length;
            var basicComparison = new CompareLogic
            {
                Config = new ComparisonConfig { MaxDifferences = propertyCount, IgnoreObjectTypes = true }
            };

            basicComparison.Config.MembersToInclude = new List<string>
            {
                "BuildingNumber",
                "FlatNumber",
                "City",
                "CountryId",
                "Street",
                "ZipCode"
            };
            var diffs = basicComparison.Compare(oldAddress, address).Differences;

            var sb = new StringBuilder();
            sb.AppendLine("Zmieniono dane adresowe:");
            foreach (var diff in diffs)
            {
                sb.AppendLine(diff.PropertyName);
                sb.AppendLine("Stara wartość: " + diff.Object1Value);
                sb.AppendLine("Nowa wartość: " + diff.Object2Value + "\n");
            }
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                sb = sb.Replace("BuildingNumber", "Nr budynku");
                sb = sb.Replace("FlatNumber", "Nr mieszkania");
                sb = sb.Replace("City", "Miasto");
                sb = sb.Replace("ZipCode", "Kod pocztowy");
                sb = sb.Replace("Street", "Ulica");
                sb = sb.Replace("CountryId", "ID kraju");
            }

            return sb.ToString();
        }

        private static PatientLogs LogPatientChanges(Patients oldPatient, Patients patient, string userName)
        {
            var propertyCount = typeof(Patients).GetProperties().Length;
            var basicComparison = new CompareLogic
            {
                Config = new ComparisonConfig { MaxDifferences = propertyCount, IgnoreObjectTypes = true }
            };

            basicComparison.Config.MembersToInclude = new List<string>
            {
                "FirstName",
                "SecondName",
                "Surname",
                "Pesel",
                "DateOfBirth",
                "CityOfBirth",
                "PhoneNumber",
                "NationalityId"
            };
            var diffs = basicComparison.Compare(oldPatient, patient).Differences;

            var sb = new StringBuilder();
            sb.AppendLine("Zmieniono dane pacjenta:");
            foreach (var diff in diffs)
            {
                sb.AppendLine(diff.PropertyName);
                sb.AppendLine("Stara wartość: " + diff.Object1Value);
                sb.AppendLine("Nowa wartość: " + diff.Object2Value + "\n");
            }
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                sb = sb.Replace("FirstName", "Imię");
                sb = sb.Replace("SecondName", "Drugie imię");
                sb = sb.Replace("Surname", "Nazwisko");
                sb = sb.Replace("DateOfBirth", "Data urodzenia");
                sb = sb.Replace("CityOfBirth", "Miejsce urodzenia");
                sb = sb.Replace("PhoneNumber", "Numer telefonu");
                sb = sb.Replace("NationalityId", "ID obywatelstwa");
            }

            var logs = new PatientLogs
            {
                EventDateTime = DateTime.Now,
                PatientId = patient.Id,
                UserName = userName,
                Content = sb.ToString()
            };

            return logs;
        }
    }
}
