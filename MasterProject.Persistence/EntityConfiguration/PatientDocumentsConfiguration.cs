namespace MasterProject.Persistence.EntityConfiguration
{
    using Core.Models;
    using System.Data.Entity.ModelConfiguration;

    public class PatientDocumentsConfiguration : EntityTypeConfiguration<PatientDocuments>
    {
        public PatientDocumentsConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.FileName).IsRequired().HasMaxLength(200);
        }
    }
}
