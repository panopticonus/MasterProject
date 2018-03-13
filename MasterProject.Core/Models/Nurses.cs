namespace MasterProject.Core.Models
{
    using System;

    public partial class Nurses
    {
        public int Id { get; set; }
        public string Pwz { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public int WardId { get; set; }
        public virtual Wards Ward { get; set; }
        public int AdressId { get; set; }
        public virtual Addresses Address { get; set; }
        public string UserId { get; set; }
        public virtual Users User { get; set; }
    }
}
