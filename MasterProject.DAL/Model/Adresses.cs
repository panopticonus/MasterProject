namespace MasterProject.DAL.Model
{
    using System.ComponentModel.DataAnnotations;

    public partial class Adresses
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Street { get; set; }

        [Required]
        [StringLength(10)]
        public string BuildingNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string FlatNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(15)]
        public string ZipCode { get; set; }

        public int CountryId { get; set; }
    }
}
