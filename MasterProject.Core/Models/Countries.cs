namespace MasterProject.Core.Models
{
    using System;

    [Serializable]
    public partial class Countries
    {
        public int Id { get; set; }
        public string IsoAlpha2 { get; set; }
        public string IsoAlpha3 { get; set; }
        public string Name { get; set; }
        public int CountryCode { get; set; }
        public bool MemberUE { get; set; }
    }
}
