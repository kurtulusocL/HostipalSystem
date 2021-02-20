namespace HospitalSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Time = c.String(),
                        IsConfirm = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        IdentityNo = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                        GenderId = c.Int(nullable: false),
                        AppointmentId = c.Int(nullable: false),
                        TitleId = c.Int(nullable: false),
                        DepartmanId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.AppointmentId, cascadeDelete: true)
                .ForeignKey("dbo.Titles", t => t.TitleId, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.Departmen", t => t.DepartmanId, cascadeDelete: true)
                .Index(t => t.GenderId)
                .Index(t => t.AppointmentId)
                .Index(t => t.TitleId)
                .Index(t => t.DepartmanId);
            
            CreateTable(
                "dbo.Departmen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        IdentityNo = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        Hiredate = c.DateTime(nullable: false),
                        Photo = c.String(),
                        IsConfirm = c.Boolean(nullable: false),
                        GenderId = c.Int(nullable: false),
                        TitleId = c.Int(nullable: false),
                        DepartmanId = c.Int(nullable: false),
                        DoctorInformationId = c.Int(nullable: false),
                        DoctorDegreeId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departmen", t => t.DepartmanId, cascadeDelete: true)
                .ForeignKey("dbo.DoctorDegrees", t => t.DoctorDegreeId, cascadeDelete: true)
                .ForeignKey("dbo.DoctorInformations", t => t.DoctorInformationId, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.Titles", t => t.TitleId, cascadeDelete: true)
                .Index(t => t.GenderId)
                .Index(t => t.TitleId)
                .Index(t => t.DepartmanId)
                .Index(t => t.DoctorInformationId)
                .Index(t => t.DoctorDegreeId);
            
            CreateTable(
                "dbo.DoctorDegrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        University = c.String(),
                        Degree = c.String(),
                        Date = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DoctorInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Province = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        EMail = c.String(),
                        PhoneNumber = c.String(),
                        HomeNumber = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        IdentityNo = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        Hiredate = c.DateTime(nullable: false),
                        Photo = c.String(),
                        IsConfirm = c.Boolean(nullable: false),
                        GenderId = c.Int(nullable: false),
                        TitleId = c.Int(nullable: false),
                        EmployeeInformationId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeInformations", t => t.EmployeeInformationId, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.Titles", t => t.TitleId, cascadeDelete: true)
                .Index(t => t.GenderId)
                .Index(t => t.TitleId)
                .Index(t => t.EmployeeInformationId);
            
            CreateTable(
                "dbo.EmployeeInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Province = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        EMail = c.String(),
                        PhoneNumber = c.String(),
                        HomeNumber = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nurses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        IdentityNo = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        Hiredate = c.DateTime(nullable: false),
                        Photo = c.String(),
                        IsConfirm = c.Boolean(nullable: false),
                        GenderId = c.Int(nullable: false),
                        DepartmanId = c.Int(nullable: false),
                        NurseInformationId = c.Int(nullable: false),
                        NurseDegreeId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departmen", t => t.DepartmanId, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.NurseDegrees", t => t.NurseDegreeId, cascadeDelete: true)
                .ForeignKey("dbo.NurseInformations", t => t.NurseInformationId, cascadeDelete: true)
                .Index(t => t.GenderId)
                .Index(t => t.DepartmanId)
                .Index(t => t.NurseInformationId)
                .Index(t => t.NurseDegreeId);
            
            CreateTable(
                "dbo.NurseDegrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        University = c.String(),
                        Degree = c.String(),
                        Date = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NurseInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Province = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        EMail = c.String(),
                        PhoneNumber = c.String(),
                        HomeNumber = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NameLastname = c.String(),
                        RespondTitle = c.String(),
                        Birthdate = c.String(),
                        Gender = c.String(),
                        HireDate = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Patients", "DepartmanId", "dbo.Departmen");
            DropForeignKey("dbo.Patients", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Nurses", "NurseInformationId", "dbo.NurseInformations");
            DropForeignKey("dbo.Nurses", "NurseDegreeId", "dbo.NurseDegrees");
            DropForeignKey("dbo.Nurses", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Nurses", "DepartmanId", "dbo.Departmen");
            DropForeignKey("dbo.Patients", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.Employees", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.Doctors", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.Employees", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Employees", "EmployeeInformationId", "dbo.EmployeeInformations");
            DropForeignKey("dbo.Doctors", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Doctors", "DoctorInformationId", "dbo.DoctorInformations");
            DropForeignKey("dbo.Doctors", "DoctorDegreeId", "dbo.DoctorDegrees");
            DropForeignKey("dbo.Doctors", "DepartmanId", "dbo.Departmen");
            DropForeignKey("dbo.Patients", "AppointmentId", "dbo.Appointments");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Nurses", new[] { "NurseDegreeId" });
            DropIndex("dbo.Nurses", new[] { "NurseInformationId" });
            DropIndex("dbo.Nurses", new[] { "DepartmanId" });
            DropIndex("dbo.Nurses", new[] { "GenderId" });
            DropIndex("dbo.Employees", new[] { "EmployeeInformationId" });
            DropIndex("dbo.Employees", new[] { "TitleId" });
            DropIndex("dbo.Employees", new[] { "GenderId" });
            DropIndex("dbo.Doctors", new[] { "DoctorDegreeId" });
            DropIndex("dbo.Doctors", new[] { "DoctorInformationId" });
            DropIndex("dbo.Doctors", new[] { "DepartmanId" });
            DropIndex("dbo.Doctors", new[] { "TitleId" });
            DropIndex("dbo.Doctors", new[] { "GenderId" });
            DropIndex("dbo.Patients", new[] { "DepartmanId" });
            DropIndex("dbo.Patients", new[] { "TitleId" });
            DropIndex("dbo.Patients", new[] { "AppointmentId" });
            DropIndex("dbo.Patients", new[] { "GenderId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.NurseInformations");
            DropTable("dbo.NurseDegrees");
            DropTable("dbo.Nurses");
            DropTable("dbo.Titles");
            DropTable("dbo.EmployeeInformations");
            DropTable("dbo.Employees");
            DropTable("dbo.Genders");
            DropTable("dbo.DoctorInformations");
            DropTable("dbo.DoctorDegrees");
            DropTable("dbo.Doctors");
            DropTable("dbo.Departmen");
            DropTable("dbo.Patients");
            DropTable("dbo.Appointments");
        }
    }
}
