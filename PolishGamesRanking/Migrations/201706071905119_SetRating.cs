namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Rating", c => c.Single(nullable: false));
            AddColumn("dbo.Games", "RatingsCount", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "AllRates", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "AllRates");
            DropColumn("dbo.Games", "RatingsCount");
            DropColumn("dbo.Games", "Rating");
        }
    }
}
