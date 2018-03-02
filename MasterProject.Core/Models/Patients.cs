namespace MasterProject.Core.Models
{
    using System;

    public partial class Patients
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public int? InsuranceId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CityOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public int NationalityId { get; set; }
    }
}