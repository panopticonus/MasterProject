namespace MasterProject.Persistence.EntityConfiguration
{
    using Core.Models;
    using System.Data.Entity.ModelConfiguration;

    public class CountriesConfiguration : EntityTypeConfiguration<Countries>
    {
        public CountriesConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.IsoAlpha2).IsRequired().HasMaxLength(2);
            Property(x => x.IsoAlpha3).IsRequired().HasMaxLength(3);
            Property(x => x.Name).IsRequired().HasMaxLength(100);
        }      
    }
}
