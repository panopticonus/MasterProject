namespace MasterProject.Core.Models
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class Patients
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public virtual Addresses Address { get; set; }
        public int? InsuranceId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CityOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public int NationalityId { get; set; }
        public virtual Countries Nationality { get; set; }
        public virtual List<PatientDocuments> PatientDocuments { get; set; }
    }
}
