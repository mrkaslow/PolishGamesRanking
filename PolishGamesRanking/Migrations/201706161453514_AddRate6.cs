namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRate6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "RateType_Id", "dbo.Rates");
            DropIndex("dbo.Games", new[] { "RateType_Id" });
            //DropColumn("dbo.Games", "Rating_Id");
            //DropColumn("dbo.Games", "RateType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "RateType_Id", c => c.Int());
            AddColumn("dbo.Games", "Rating_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Games", "RateType_Id");
            AddForeignKey("dbo.Games", "RateType_Id", "dbo.Rates", "Id");
        }
    }
}
