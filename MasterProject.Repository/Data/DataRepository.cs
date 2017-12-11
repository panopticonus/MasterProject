namespace MasterProject.Repository.Data
{
    using Contracts.HospitalRepository;
    using DAL;
    using DAL.Migrations;
    using System.Data.Entity;

    public class DataRepository : IRepositoryData
    {
        public void UpdateDatabasesToTheLatestVersion()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalContext, Configuration>());
        }
    }
}
