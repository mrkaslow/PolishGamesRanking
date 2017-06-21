namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GamesCount1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RatedGames",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        GameId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RatedGames", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RatedGames", new[] { "ApplicationUser_Id" });
            DropTable("dbo.RatedGames");
        }
    }
}
