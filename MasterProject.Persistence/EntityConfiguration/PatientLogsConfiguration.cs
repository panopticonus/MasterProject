namespace MasterProject.Persistence.EntityConfiguration
{
    using Core.Models;
    using System.Data.Entity.ModelConfiguration;

    public class PatientLogsConfiguration : EntityTypeConfiguration<PatientLogs>
    {
        public PatientLogsConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Content).IsRequired().HasMaxLength(4000);
            Property(x => x.UserName).IsRequired().HasMaxLength(200);
        }
    }
}
