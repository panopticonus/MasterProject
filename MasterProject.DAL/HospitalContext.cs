namespace MasterProject.DAL
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model;
    using System.Data.Entity;

    public class HospitalContext : IdentityDbContext<AppUser>
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
            modelBuilder.Entity<Countries>()
                .Property(e => e.IsoAlpha2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Countries>()
                .Property(e => e.IsoAlpha3)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Patients>()
                .Property(e => e.Pesel)
                .IsFixedLength();

            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
