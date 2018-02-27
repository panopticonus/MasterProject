namespace MasterProject.Core.Models
{
    using System;

    public partial class WardStays
    {
        public int Id { get; set; }
        public int HospitalStayId { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public DateTime? DateOfDischarge { get; set; }
        public int WardId { get; set; }
        public int DoctorId { get; set; }
    }
}
