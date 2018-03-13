namespace MasterProject.Persistence.EntityConfiguration
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Models;

    public class AddressesConfiguration : EntityTypeConfiguration<Addresses>
    {
        public AddressesConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Street).IsRequired().HasMaxLength(100);
            Property(x => x.BuildingNumber).IsRequired().HasMaxLength(10);
            Property(x => x.FlatNumber).IsRequired().HasMaxLength(10);
            Property(x => x.City).IsRequired().HasMaxLength(100);
            Property(x => x.ZipCode).IsRequired().HasMaxLength(15);
        }
    }
}
