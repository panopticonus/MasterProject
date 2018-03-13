namespace MasterProject.Persistence.EntityConfiguration
{
    using Core.Models;
    using System.Data.Entity.ModelConfiguration;

    public class SpecialtiesConfiguration : EntityTypeConfiguration<Specialties>
    {
        public SpecialtiesConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Code).IsRequired().HasMaxLength(4);
            Property(x => x.Name).IsRequired().HasMaxLength(250);
        }
    }
}
