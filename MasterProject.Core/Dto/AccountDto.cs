using System;

namespace MasterProject.Core.Dto
{
    public class AccountDto
    {
        public int Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public string UserId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int WardId { get; set; }
        public string Degree { get; set; }
        public string Pwz { get; set; }
        public int DegreeOfSpecialty { get; set; }
        public int SpecialtyId { get; set; }
    }
}
