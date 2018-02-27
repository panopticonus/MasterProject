namespace MasterProject.Core.Interfaces.Repositories
{
    using Dto;
    using System.Collections.Generic;

    public interface ILanguagesRepository
    {
        List<Country> GetCountriesList();
    }
}
