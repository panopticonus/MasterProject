namespace MasterProject.Core.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ErrorLogs
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string CallStack { get; set; }
        public int? ParentErrorId { get; set; }
        public string Source { get; set; }
    }
}
