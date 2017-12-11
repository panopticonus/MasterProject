namespace MasterProject.DAL
{
    using Model;
    using System.Data.Entity;

    public partial class HospitalContext : DbContext
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
        }
    }
}
