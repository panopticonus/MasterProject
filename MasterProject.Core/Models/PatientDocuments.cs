namespace MasterProject.Core.Models
{
    using System;

    [Serializable]
    public class PatientDocuments
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public virtual Patients Patient { get; set; }
        public DateTime AdditionDateTime { get; set; }
        public string FileName { get; set; }
        public string UserId { get; set; }
        public virtual Users User { get; set; }
    }
}
