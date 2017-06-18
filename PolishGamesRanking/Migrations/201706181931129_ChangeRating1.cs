namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRating1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Rating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
