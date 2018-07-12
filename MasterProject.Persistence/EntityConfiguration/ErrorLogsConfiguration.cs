namespace MasterProject.Persistence.EntityConfiguration
{
    using Core.Models;
    using System.Data.Entity.ModelConfiguration;

    public class ErrorLogsConfiguration : EntityTypeConfiguration<ErrorLogs>
    {
        public ErrorLogsConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Message).IsRequired().HasMaxLength(4000);
            Property(x => x.CallStack).IsRequired().HasColumnType("text");
            Property(x => x.Source).HasMaxLength(500);
        }
    }
}
