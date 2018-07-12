namespace MasterProject.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatientNotes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        Content = c.String(nullable: false, maxLength: 4000),
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
            DropForeignKey("dbo.PatientNotes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PatientNotes", "PatientId", "dbo.Patients");
            DropIndex("dbo.PatientNotes", new[] { "UserId" });
            DropIndex("dbo.PatientNotes", new[] { "PatientId" });
            DropTable("dbo.PatientNotes");
        }
    }
}
