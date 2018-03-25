namespace MasterProject.Persistence
{
    using Core;
    using Core.Models;
    using EntityConfiguration;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq;

    public class HospitalContext : IdentityDbContext<Users>, IHospitalContext
    {
        public HospitalContext()
            : base("name=HospitalContext")
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<HospitalStays> HospitalStays { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Wards> Wards { get; set; }
        public virtual DbSet<WardStays> WardStays { get; set; }
        public virtual DbSet<Nurses> Nurses { get; set; }
        public virtual DbSet<Specialties> Specialties { get; set; }
        public virtual DbSet<Roles> ExpandedRoles { get; set; }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressesConfiguration());
            modelBuilder.Configurations.Add(new CountriesConfiguration());
            modelBuilder.Configurations.Add(new PatientsConfiguration());
            modelBuilder.Configurations.Add(new UsersConfiguration());
            modelBuilder.Configurations.Add(new WardsConfiguration());
            modelBuilder.Configurations.Add(new DoctorsConfiguration());
            modelBuilder.Configurations.Add(new NursesConfiguration());
            modelBuilder.Configurations.Add(new SpecialtiesConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
