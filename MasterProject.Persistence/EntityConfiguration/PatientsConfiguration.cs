namespace MasterProject.Persistence.EntityConfiguration
{
    using Core.Models;
    using System.Data.Entity.ModelConfiguration;

    public class PatientsConfiguration : EntityTypeConfiguration<Patients>
    {
        public PatientsConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            Property(x => x.SecondName).IsRequired().HasMaxLength(100);
            Property(x => x.Surname).IsRequired().HasMaxLength(100);
            Property(x => x.Surname).IsRequired().HasMaxLength(100);
            Property(x => x.Pesel).IsRequired().HasMaxLength(11);
            Property(x => x.CityOfBirth).IsRequired().HasMaxLength(50);
            Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);
        }
    }
}
