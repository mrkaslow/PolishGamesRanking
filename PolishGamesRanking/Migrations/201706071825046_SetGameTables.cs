namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetGameTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Games", "Developer", c => c.String());
            AlterColumn("dbo.Games", "Publisher", c => c.String());
            AlterColumn("dbo.Games", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
