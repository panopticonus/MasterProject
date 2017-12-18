namespace MasterProject.Manager.Languages
{
    using System.Collections.Generic;
    using Contracts.Class;
    using Contracts.HospitalManager;
    using Contracts.HospitalRepository;
    using Repository.Languages;

    public class LanguagesManager : IManagerLanguages
    {
        private readonly IRepositoryLanguages _repository;

        public LanguagesManager()
        {
            this._repository = new LanguagesRepository();
        }

        public List<Country> GetCountriesList()
        {
            return _repository.GetCountriesList();
        }
    }
}
