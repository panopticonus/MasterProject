namespace MasterProject.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddErrorLogs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ErrorLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Message = c.String(nullable: false, maxLength: 4000),
                        CallStack = c.String(nullable: false, unicode: false, storeType: "text"),
                        ParentErrorId = c.Int(),
                        Source = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ErrorLogs");
        }
    }
}
