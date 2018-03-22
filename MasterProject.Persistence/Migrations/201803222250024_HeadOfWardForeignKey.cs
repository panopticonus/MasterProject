namespace MasterProject.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HeadOfWardForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Nurses", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Nurses", new[] { "Address_Id" });
            RenameColumn(table: "dbo.Nurses", name: "Address_Id", newName: "AddressId");
            AlterColumn("dbo.Wards", "HeadOfWardId", c => c.Int());
            AlterColumn("dbo.Nurses", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Wards", "HeadOfWardId");
            CreateIndex("dbo.Nurses", "AddressId");
            CreateIndex("dbo.Patients", "AddressId");
            AddForeignKey("dbo.Wards", "HeadOfWardId", "dbo.Doctors", "Id");
            AddForeignKey("dbo.Patients", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Nurses", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
            DropColumn("dbo.Nurses", "AdressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nurses", "AdressId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Nurses", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Patients", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Wards", "HeadOfWardId", "dbo.Doctors");
            DropIndex("dbo.Patients", new[] { "AddressId" });
            DropIndex("dbo.Nurses", new[] { "AddressId" });
            DropIndex("dbo.Wards", new[] { "HeadOfWardId" });
            AlterColumn("dbo.Nurses", "AddressId", c => c.Int());
            AlterColumn("dbo.Wards", "HeadOfWardId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Nurses", name: "AddressId", newName: "Address_Id");
            CreateIndex("dbo.Nurses", "Address_Id");
            AddForeignKey("dbo.Nurses", "Address_Id", "dbo.Addresses", "Id");
        }
    }
}
