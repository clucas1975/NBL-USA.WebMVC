namespace NBL_USA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FrontOfficeStaff",
                c => new
                    {
                        FrontOfficeStaffId = c.Int(nullable: false, identity: true),
                        TeamId = c.Int(),
                        RosterId = c.Int(),
                        TeamGeneralManagerName = c.String(nullable: false),
                        AcademicAdvisorName = c.String(nullable: false),
                        DirectorOfBasketballOperationsName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FrontOfficeStaffId)
                .ForeignKey("dbo.Roster", t => t.RosterId)
                .ForeignKey("dbo.Team", t => t.TeamId)
                .Index(t => t.TeamId)
                .Index(t => t.RosterId);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamOwner = c.String(nullable: false),
                        TeamName = c.String(nullable: false),
                        TeamLocation = c.String(nullable: false),
                        TeamArena = c.String(nullable: false),
                        TeamPlayers = c.String(nullable: false),
                        FrontOfficeStaff_FrontOfficeStaffId = c.Int(),
                        Roster_RosterId = c.Int(),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.FrontOfficeStaff", t => t.FrontOfficeStaff_FrontOfficeStaffId)
                .ForeignKey("dbo.Roster", t => t.Roster_RosterId)
                .Index(t => t.FrontOfficeStaff_FrontOfficeStaffId)
                .Index(t => t.Roster_RosterId);
            
            CreateTable(
                "dbo.Roster",
                c => new
                    {
                        RosterId = c.Int(nullable: false, identity: true),
                        CoachName = c.String(nullable: false),
                        AssistantCoachName = c.String(nullable: false),
                        StillActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RosterId);
            
            CreateTable(
                "dbo.LeagueStaff",
                c => new
                    {
                        LeagueStaffId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        LeagueStaffName = c.String(nullable: false),
                        LeagueStaffPosition = c.String(nullable: false),
                        LeagueStaffStillWorking = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LeagueStaffId);
            
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
            DropForeignKey("dbo.FrontOfficeStaff", "TeamId", "dbo.Team");
            DropForeignKey("dbo.FrontOfficeStaff", "RosterId", "dbo.Roster");
            DropForeignKey("dbo.Team", "Roster_RosterId", "dbo.Roster");
            DropForeignKey("dbo.Team", "FrontOfficeStaff_FrontOfficeStaffId", "dbo.FrontOfficeStaff");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Team", new[] { "Roster_RosterId" });
            DropIndex("dbo.Team", new[] { "FrontOfficeStaff_FrontOfficeStaffId" });
            DropIndex("dbo.FrontOfficeStaff", new[] { "RosterId" });
            DropIndex("dbo.FrontOfficeStaff", new[] { "TeamId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.LeagueStaff");
            DropTable("dbo.Roster");
            DropTable("dbo.Team");
            DropTable("dbo.FrontOfficeStaff");
        }
    }
}
