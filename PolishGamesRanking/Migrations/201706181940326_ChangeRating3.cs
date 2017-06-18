namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRating3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Rating", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
