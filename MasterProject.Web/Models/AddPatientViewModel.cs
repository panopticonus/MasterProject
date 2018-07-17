namespace MasterProject.Web.Models
{
    using Core.Dto;
    using System.Collections.Generic;

    public class AddPatientViewModel
    {
        public List<CountryHeaderDto> Countries { get; set; }
        public int PolishCountryId { get; set; }
    }
}