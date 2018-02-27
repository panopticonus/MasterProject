namespace MasterProject.Persistence.EntityConfiguration
{
    using Core.Models;
    using System.Data.Entity.ModelConfiguration;

    public class UsersConfiguration : EntityTypeConfiguration<Users>
    {
        public UsersConfiguration()
        {
            Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            Property(x => x.LastName).IsRequired().HasMaxLength(100);
        }
    }
}
