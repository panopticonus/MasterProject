namespace MasterProject.Manager.Data
{
    using Contracts.HospitalManager;
    using Contracts.HospitalRepository;
    using Repository.Data;

    public class DataManager : IManagerData
    {
        private readonly IRepositoryData _repository;

        public DataManager()
        {
            _repository = new DataRepository();
        }
        public void UpdateDatabasesToTheLatestVersion()
        {
            _repository.UpdateDatabasesToTheLatestVersion();
        }
    }
}
