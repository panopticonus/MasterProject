namespace MasterProject.Core.Models
{
    using System;

    [Serializable]
    public partial class Addresses
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int CountryId { get; set; }
        public virtual Countries Country { get; set; }
    }
}
