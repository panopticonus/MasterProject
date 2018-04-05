namespace MasterProject.Core.Dto
{
    using System;

    public class PatientDto
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CityOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public int NationalityId { get; set; }
    }
}
