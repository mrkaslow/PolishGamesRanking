namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Rating_Id", c => c.Byte(nullable: false));
            DropColumn("dbo.Games", "RatingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "RatingId", c => c.Byte(nullable: false));
            DropColumn("dbo.Games", "Rating_Id");
        }
    }
}
