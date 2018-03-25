namespace MasterProject.Core
{
    using Models;
    using System.Data.Entity;

    public interface IHospitalContext
    {
        DbSet<Addresses> Addresses { get; set; }
        DbSet<Countries> Countries { get; set; }
        DbSet<Doctors> Doctors { get; set; }
        DbSet<HospitalStays> HospitalStays { get; set; }
        DbSet<Patients> Patients { get; set; }
        DbSet<Wards> Wards { get; set; }
        DbSet<WardStays> WardStays { get; set; }
        DbSet<Nurses> Nurses { get; set; }
        DbSet<Specialties> Specialties { get; set; }
        DbSet<Roles> ExpandedRoles { get; set; }
        int SaveChanges();
    }
}
