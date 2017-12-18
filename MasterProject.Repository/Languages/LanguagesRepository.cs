namespace MasterProject.Repository.Languages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts.Class;
    using Contracts.HospitalRepository;
    using DAL;

    public class LanguagesRepository : IRepositoryLanguages
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
