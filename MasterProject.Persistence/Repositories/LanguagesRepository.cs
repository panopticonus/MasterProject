namespace MasterProject.Persistence.Repositories
{
    using Core.Dto;
    using Core.Interfaces.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LanguagesRepository : ILanguagesRepository
    {
        public List<CountryHeaderDto> GetCountriesList()
        {
            var context = new HospitalContext();

            try
            {
                var countryList = (from countries in context.Countries
                                   select new CountryHeaderDto
                                   {
                                       Id = countries.Id,
                                       Name = countries.Name
                                   }).OrderBy(x => x.Name).ToList();

                return countryList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
