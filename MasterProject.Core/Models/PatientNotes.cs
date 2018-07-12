namespace MasterProject.Core.Models
{
    using System;

    public class PatientNotes
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public virtual Patients Patient { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public virtual Users User { get; set; }
    }
}
