namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingImage1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            DropColumn("dbo.Games", "ImageSize");
            DropColumn("dbo.Games", "FileName");
            DropColumn("dbo.Games", "ImageData");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "ImageData", c => c.Binary());
            AddColumn("dbo.Games", "FileName", c => c.String());
            AddColumn("dbo.Games", "ImageSize", c => c.Int(nullable: false));
            DropForeignKey("dbo.Files", "GameId", "dbo.Games");
            DropIndex("dbo.Files", new[] { "GameId" });
            DropTable("dbo.Files");
        }
    }
}
