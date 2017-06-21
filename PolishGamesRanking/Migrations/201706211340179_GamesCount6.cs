namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GamesCount6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RatedGames", "UsersRate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RatedGames", "UsersRate");
        }
    }
}
