namespace MasterProject.Core
{
    using Models;
    using System.Data.Entity;

    public interface IHospitalContext
    {
        DbSet<Adresses> Adresses { get; set; }
        DbSet<Countries> Countries { get; set; }
        DbSet<Doctors> Doctors { get; set; }
        DbSet<HospitalStays> HospitalStays { get; set; }
        DbSet<Patients> Patients { get; set; }
        DbSet<Wards> Wards { get; set; }
        DbSet<WardStays> WardStays { get; set; }
    }
}
