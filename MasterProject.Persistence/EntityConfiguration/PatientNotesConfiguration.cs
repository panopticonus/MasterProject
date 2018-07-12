namespace MasterProject.Persistence.EntityConfiguration
{
    using Core.Models;
    using System.Data.Entity.ModelConfiguration;

    public class PatientNotesConfiguration : EntityTypeConfiguration<PatientNotes>
    {
        public PatientNotesConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Content).IsRequired().HasMaxLength(4000);
        }
    }
}
