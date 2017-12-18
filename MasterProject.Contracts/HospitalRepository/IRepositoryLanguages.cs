namespace MasterProject.Contracts.HospitalRepository
{
    using Class;
    using System.Collections.Generic;

    public interface IRepositoryLanguages
    {
        List<Country> GetCountriesList();
    }
}
