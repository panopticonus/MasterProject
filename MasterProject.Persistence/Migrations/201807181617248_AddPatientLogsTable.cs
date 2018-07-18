namespace MasterProject.Persistence.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddPatientLogsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 200),
                        Content = c.String(nullable: false, maxLength: 4000),
                        EventDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientLogs", "PatientId", "dbo.Patients");
            DropIndex("dbo.PatientLogs", new[] { "PatientId" });
            DropTable("dbo.PatientLogs");
        }
    }
}
