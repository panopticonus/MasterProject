namespace MasterProject.Persistence.EntityConfiguration
{
    using Core.Models;
    using System.Data.Entity.ModelConfiguration;

    public class WardsConfiguration : EntityTypeConfiguration<Wards>
    {
        public WardsConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}
