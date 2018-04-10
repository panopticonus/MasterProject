namespace MasterProject.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FkCountries : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Addresses", "CountryId");
            CreateIndex("dbo.Patients", "NationalityId");
            AddForeignKey("dbo.Addresses", "CountryId", "dbo.Countries", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Patients", "NationalityId", "dbo.Countries", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "NationalityId", "dbo.Countries");
            DropForeignKey("dbo.Addresses", "CountryId", "dbo.Countries");
            DropIndex("dbo.Patients", new[] { "NationalityId" });
            DropIndex("dbo.Addresses", new[] { "CountryId" });
        }
    }
}
