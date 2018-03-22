namespace MasterProject.Persistence
{
    using Core;
    using Core.Models;
    using EntityConfiguration;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

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
