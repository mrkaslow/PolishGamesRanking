namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRate7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "RatingId", c => c.Byte(nullable: false));
            AddColumn("dbo.Games", "RateType_Id", c => c.Int());
            CreateIndex("dbo.Games", "RateType_Id");
            AddForeignKey("dbo.Games", "RateType_Id", "dbo.Rates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "RateType_Id", "dbo.Rates");
            DropIndex("dbo.Games", new[] { "RateType_Id" });
            DropColumn("dbo.Games", "RateType_Id");
            DropColumn("dbo.Games", "RatingId");
        }
    }
}
