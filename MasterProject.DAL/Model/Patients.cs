namespace MasterProject.DAL.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Patients
    {
        public int Id { get; set; }

        public int AddressId { get; set; }

        public int? InsuranceId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string SecondName { get; set; }

        [StringLength(100)]
        public string Surname { get; set; }

        [Required]
        [StringLength(11)]
        public string Pesel { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(50)]
        public string CityOfBirth { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public int NationalityId { get; set; }
    }
}
