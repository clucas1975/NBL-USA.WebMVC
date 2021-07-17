namespace NBL_USA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeCorrections : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FrontOfficeStaff",
                c => new
                    {
                        FrontOfficeStaffID = c.Int(nullable: false, identity: true),
                        TeamID = c.Int(nullable: false),
                        RosterID = c.Int(nullable: false),
                        TeamGeneralManagerName = c.String(nullable: false),
                        AcademicAdvisorName = c.String(nullable: false),
                        DirectorOfBasketballOperationsName = c.String(nullable: false),
                        FrontOfficeStaff_FrontOfficeStaffID = c.Int(),
                    })
                .PrimaryKey(t => t.FrontOfficeStaffID)
                .ForeignKey("dbo.FrontOfficeStaff", t => t.FrontOfficeStaff_FrontOfficeStaffID)
                .ForeignKey("dbo.Roster", t => t.RosterID, cascadeDelete: true)
                .ForeignKey("dbo.Team", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.TeamID)
                .Index(t => t.RosterID)
                .Index(t => t.FrontOfficeStaff_FrontOfficeStaffID);
            
            CreateTable(
                "dbo.Roster",
                c => new
                    {
                        RosterID = c.Int(nullable: false, identity: true),
                        CoachName = c.String(nullable: false),
                        AssistantCoachName = c.String(nullable: false),
                        StillActive = c.Boolean(nullable: false),
                        Roster_RosterID = c.Int(),
                    })
                .PrimaryKey(t => t.RosterID)
                .ForeignKey("dbo.Roster", t => t.Roster_RosterID)
                .Index(t => t.Roster_RosterID);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        TeamOwner = c.String(nullable: false),
                        TeamName = c.String(nullable: false),
                        TeamLocation = c.String(nullable: false),
                        TeamArena = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TeamID);
            
            CreateTable(
                "dbo.LeagueStaff",
                c => new
                    {
                        LeagueStaffID = c.Int(nullable: false, identity: true),
                        LeagueStaffName = c.String(nullable: false),
                        LeagueStaffPosition = c.String(nullable: false),
                        LeagueStaffStillWorking = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LeagueStaffID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.FrontOfficeStaff", "TeamID", "dbo.Team");
            DropForeignKey("dbo.FrontOfficeStaff", "RosterID", "dbo.Roster");
            DropForeignKey("dbo.Roster", "Roster_RosterID", "dbo.Roster");
            DropForeignKey("dbo.FrontOfficeStaff", "FrontOfficeStaff_FrontOfficeStaffID", "dbo.FrontOfficeStaff");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Roster", new[] { "Roster_RosterID" });
            DropIndex("dbo.FrontOfficeStaff", new[] { "FrontOfficeStaff_FrontOfficeStaffID" });
            DropIndex("dbo.FrontOfficeStaff", new[] { "RosterID" });
            DropIndex("dbo.FrontOfficeStaff", new[] { "TeamID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.LeagueStaff");
            DropTable("dbo.Team");
            DropTable("dbo.Roster");
            DropTable("dbo.FrontOfficeStaff");
        }
    }
}
