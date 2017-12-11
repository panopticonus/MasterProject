namespace MasterProject.DAL.Model
{
    using System.ComponentModel.DataAnnotations;

    public partial class Countries
    {
        public int Id { get; set; }

        [Required]
        [StringLength(2)]
        public string IsoAlpha2 { get; set; }

        [Required]
        [StringLength(3)]
        public string IsoAlpha3 { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int CountryCode { get; set; }

        public bool MemberUE { get; set; }
    }
}
