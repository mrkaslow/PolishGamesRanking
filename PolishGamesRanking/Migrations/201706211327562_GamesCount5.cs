namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GamesCount5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RatedGames", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RatedGames", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.RatedGames", "ApplicationUserId", c => c.String());
            DropColumn("dbo.RatedGames", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RatedGames", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.RatedGames", "ApplicationUserId");
            CreateIndex("dbo.RatedGames", "ApplicationUser_Id");
            AddForeignKey("dbo.RatedGames", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
