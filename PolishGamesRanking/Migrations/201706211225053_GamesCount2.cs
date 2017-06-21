namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GamesCount2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.RatedGames");
            AlterColumn("dbo.RatedGames", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.RatedGames", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.RatedGames");
            AlterColumn("dbo.RatedGames", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.RatedGames", "Id");
        }
    }
}
