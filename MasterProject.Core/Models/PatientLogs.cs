namespace MasterProject.Core.Models
{
    using System;

    public class PatientLogs
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime EventDateTime { get; set; }
        public virtual Patients Patient { get; set; }
    }
}
