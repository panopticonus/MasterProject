namespace MasterProject.Web.Models
{
    using System.Collections.Generic;
    using Core.Dto;

    public class AddAccountDetailsViewModel
    {
        public List<CountryHeaderDto> Countries { get; set; }
        public int RoleId { get; set; }
        public string UserId { get; set; }
    }
}