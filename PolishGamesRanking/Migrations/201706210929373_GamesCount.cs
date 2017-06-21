namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GamesCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "GamesAdded", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "GamesRatedCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "GamesRatedCount");
            DropColumn("dbo.AspNetUsers", "GamesAdded");
        }
    }
}
