namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GamesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Nick", c => c.String());
            AddColumn("dbo.Users", "GamesAdded", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "GamesRated", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "GamesRated");
            DropColumn("dbo.Users", "GamesAdded");
            DropColumn("dbo.Users", "Nick");
        }
    }
}
