namespace NBL_USA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeamCorrections : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Team", "TeamPlayers", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Team", "TeamPlayers", c => c.String(nullable: false));
        }
    }
}
