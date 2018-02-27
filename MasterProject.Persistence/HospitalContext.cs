namespace MasterProject.Persistence
{
    using Core;
    using Core.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using EntityConfiguration;

    public class HospitalContext : IdentityDbContext<Users>, IHospitalContext
    {
        public HospitalContext()
            : base("name=HospitalContext")
        {
        }

        public virtual DbSet<Adresses> Adresses { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<HospitalStays> HospitalStays { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Wards> Wards { get; set; }
        public virtual DbSet<WardStays> WardStays { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdressesConfiguration());
            modelBuilder.Configurations.Add(new CountriesConfiguration());
            modelBuilder.Configurations.Add(new PatientsConfiguration());
            modelBuilder.Configurations.Add(new UsersConfiguration());
            modelBuilder.Configurations.Add(new WardsConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
