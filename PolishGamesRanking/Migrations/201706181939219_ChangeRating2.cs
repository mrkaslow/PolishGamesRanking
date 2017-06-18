namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRating2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Games", "Rating");
        }
        
        public override void Down()
        {
        }
    }
}
