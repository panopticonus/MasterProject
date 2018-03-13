namespace MasterProject.Persistence.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
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
                        IsoAlpha2 = c.String(nullable: false, maxLength: 2),
                        IsoAlpha3 = c.String(nullable: false, maxLength: 3),
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
                        Pwz = c.String(nullable: false, maxLength: 7),
                        Degree = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 100),
                        DateOfBirth = c.DateTime(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        WardId = c.Int(nullable: false),
                        DegreeOfSpecialty = c.Int(nullable: false),
                        SpecialtyId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Specialties", t => t.SpecialtyId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Wards", t => t.WardId, cascadeDelete: true)
                .Index(t => t.WardId)
                .Index(t => t.SpecialtyId)
                .Index(t => t.AddressId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Code = c.String(nullable: false, maxLength: 4),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        IsDataComplete = c.Boolean(nullable: false, defaultValue: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                "dbo.HospitalStays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nurses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pwz = c.String(nullable: false, maxLength: 7),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 100),
                        DateOfBirth = c.DateTime(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        WardId = c.Int(nullable: false),
                        AdressId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Wards", t => t.WardId, cascadeDelete: true)
                .Index(t => t.WardId)
                .Index(t => t.UserId)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        InsuranceId = c.Int(),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        SecondName = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 100),
                        Pesel = c.String(nullable: false, maxLength: 11),
                        DateOfBirth = c.DateTime(nullable: false),
                        CityOfBirth = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        NationalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Nurses", "WardId", "dbo.Wards");
            DropForeignKey("dbo.Nurses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Nurses", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Doctors", "WardId", "dbo.Wards");
            DropForeignKey("dbo.Doctors", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Doctors", "SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.Doctors", "AddressId", "dbo.Addresses");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Nurses", new[] { "Address_Id" });
            DropIndex("dbo.Nurses", new[] { "UserId" });
            DropIndex("dbo.Nurses", new[] { "WardId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Doctors", new[] { "UserId" });
            DropIndex("dbo.Doctors", new[] { "AddressId" });
            DropIndex("dbo.Doctors", new[] { "SpecialtyId" });
            DropIndex("dbo.Doctors", new[] { "WardId" });
            DropTable("dbo.WardStays");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Patients");
            DropTable("dbo.Nurses");
            DropTable("dbo.HospitalStays");
            DropTable("dbo.Wards");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Specialties");
            DropTable("dbo.Doctors");
            DropTable("dbo.Countries");
            DropTable("dbo.Addresses");
        }
    }
}
