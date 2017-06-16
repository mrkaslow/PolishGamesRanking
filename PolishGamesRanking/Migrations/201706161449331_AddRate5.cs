namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRate5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Games", "Rating_Id");
        }
        
        public override void Down()
        {
        }
    }
}
