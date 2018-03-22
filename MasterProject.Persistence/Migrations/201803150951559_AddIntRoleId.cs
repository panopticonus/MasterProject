namespace MasterProject.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIntRoleId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "RoleId", c => c.Int());
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropColumn("dbo.AspNetRoles", "RoleId");
        }
    }
}
