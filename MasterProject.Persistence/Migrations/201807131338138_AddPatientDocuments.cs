namespace MasterProject.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatientDocuments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientDocuments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        AdditionDateTime = c.DateTime(nullable: false),
                        FileName = c.String(nullable: false, maxLength: 200),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.PatientId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientDocuments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PatientDocuments", "PatientId", "dbo.Patients");
            DropIndex("dbo.PatientDocuments", new[] { "UserId" });
            DropIndex("dbo.PatientDocuments", new[] { "PatientId" });
            DropTable("dbo.PatientDocuments");
        }
    }
}
