namespace MasterProject.Persistence.Migrations
{
    using System.Data.Entity.Migrations;
    using Core.Models;

    public sealed class Configuration : DbMigrationsConfiguration<HospitalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HospitalContext context)
        {
            context.Wards.AddOrUpdate(new Wards {Name = "Oddział Ginekologiczno-Położniczy"});
            context.Wards.AddOrUpdate(new Wards { Name = "Szpitalny Oddział Ratunkowy" });

            context.SaveChanges();
            //This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.E.g.
        }
    }
}
