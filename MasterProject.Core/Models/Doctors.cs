namespace MasterProject.Core.Models
{
    using System;

    public partial class Doctors
    {
        public int Id { get; set; }
        public string Pwz { get; set; }
        public string Degree { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public int WardId { get; set; }
        public virtual Wards Ward { get; set; }
        public int DegreeOfSpecialty { get; set; }
        public int SpecialtyId { get; set; }
        public virtual Specialties Specialty { get; set; }
        public int AddressId { get; set; }
        public virtual Addresses Address { get; set; }
        public string UserId { get; set; }
        public virtual Users User { get; set; }
    }
}
