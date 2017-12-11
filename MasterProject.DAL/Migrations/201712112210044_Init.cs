namespace MasterProject.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false, maxLength: 100),
                        BuildingNumber = c.String(nullable: false, maxLength: 10),
                        FlatNumber = c.String(nullable: false, maxLength: 10),
                        City = c.String(nullable: false, maxLength: 100),
                        ZipCode = c.String(nullable: false, maxLength: 15),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsoAlpha2 = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false),
                        IsoAlpha3 = c.String(nullable: false, maxLength: 3, fixedLength: true, unicode: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        CountryCode = c.Int(nullable: false),
                        MemberUE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HospitalStays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        InsuranceId = c.Int(),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        SecondName = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(maxLength: 100),
                        Pesel = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        DateOfBirth = c.DateTime(nullable: false),
                        CityOfBirth = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        NationalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Wards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        HeadOfWardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WardStays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HospitalStayId = c.Int(nullable: false),
                        DateOfAdmission = c.DateTime(nullable: false),
                        DateOfDischarge = c.DateTime(),
                        WardId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WardStays");
            DropTable("dbo.Wards");
            DropTable("dbo.Patients");
            DropTable("dbo.HospitalStays");
            DropTable("dbo.Doctors");
            DropTable("dbo.Countries");
            DropTable("dbo.Adresses");
        }
    }
}
