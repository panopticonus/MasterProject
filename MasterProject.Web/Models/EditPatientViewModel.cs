namespace MasterProject.Web.Models
{
    using Core.Dto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class EditPatientViewModel
    {
        public int Id { get; set; }
        [DisplayName("Imię:")]
        public string FirstName { get; set; }
        [DisplayName("Nazwisko:")]
        public string Surname { get; set; }
        [DisplayName("Pesel:")]
        public string Pesel { get; set; }
        [DisplayName("Miasto:")]
        public string City { get; set; }
        [DisplayName("Numer telefonu:")]
        public string PhoneNumber { get; set; }
        [DisplayName("Drugie imię:")]
        public string SecondName { get; set; }
        [DisplayName("Data urodzenia:")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Miejsce urodzenia:")]
        public string CityOfBirth { get; set; }
        [DisplayName("Ulica:")]
        public string Street { get; set; }
        [DisplayName("Nr domu:")]
        public string BuildingNumber { get; set; }
        [DisplayName("Nr mieszkania:")]
        public string FlatNumber { get; set; }
        [DisplayName("Kod pocztowy:")]
        public string ZipCode { get; set; }
        public int CountryId { get; set; }
        public int NationalityId { get; set; }
        [DisplayName("Obywatelstwo:")]
        public List<CountryHeaderDto> Nationalities { get; set; }
        [DisplayName("Kraj:")]
        public List<CountryHeaderDto> Countries { get; set; }
        public string CountryName { get; set; }
        public string NationalityName { get; set; }
        public List<PatientNotesDto> PatientNotes { get; set; }
        public List<PatientDocumentsDto> PatientDocuments { get; set; }
    }
}