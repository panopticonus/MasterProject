namespace MasterProject.Core.Models
{
    public partial class Wards
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? HeadOfWardId { get; set; }
        public virtual Doctors HeadOfWard { get; set; }
    }
}
