namespace MasterProject.DAL.Model
{
    using System.ComponentModel.DataAnnotations;

    public partial class Wards
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int HeadOfWardId { get; set; }
    }
}
