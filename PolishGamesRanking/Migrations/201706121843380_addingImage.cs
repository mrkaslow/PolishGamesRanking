namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingImage : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Games", new[] { "GameImage_Id" });
            AddColumn("dbo.Games", "ImageSize", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "FileName", c => c.String());
            AddColumn("dbo.Games", "ImageData", c => c.Binary());
            DropColumn("dbo.Games", "GameImage_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "GameImage_Id", c => c.Int());
            DropColumn("dbo.Games", "ImageData");
            DropColumn("dbo.Games", "FileName");
            DropColumn("dbo.Games", "ImageSize");
            CreateIndex("dbo.Games", "GameImage_Id");
        }
    }
}
