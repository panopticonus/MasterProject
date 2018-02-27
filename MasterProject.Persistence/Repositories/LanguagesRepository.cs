namespace MasterProject.Persistence.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Dto;
    using Core.Interfaces.Repositories;

    public class LanguagesRepository : ILanguagesRepository
    {
        public List<Country> GetCountriesList()
        {
            var context = new HospitalContext();

            try
            {
                var countryList = (from countries in context.Countries
                                   select new Country
                                   {
                                       Id = countries.Id,
                                       CountryCode = countries.CountryCode,
                                       IsoAlpha2 = countries.IsoAlpha2,
                                       IsoAlpha3 = countries.IsoAlpha3,
                                       MemberUE = countries.MemberUE,
                                       Name = countries.Name
                                   }).ToList();

                return countryList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
