namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Description : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Description", c => c.String());
            AddColumn("dbo.Games", "DLC", c => c.Boolean(nullable: false));
            AddColumn("dbo.Games", "Engine", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "Engine");
            DropColumn("dbo.Games", "DLC");
            DropColumn("dbo.Games", "Description");
        }
    }
}
