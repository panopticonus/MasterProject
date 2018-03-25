namespace MasterProject.Web.Models
{
    using System.Collections.Generic;
    using Core.Dto;
    using Core.Models;

    public class AddAccountDetailsViewModel
    {
        public List<CountryHeaderDto> Countries { get; set; }
        public int RoleId { get; set; }
        public string UserId { get; set; }
        public List<Wards> Wards { get; set; }
        public List<Specialties> Specialties { get; set; }
    }
}