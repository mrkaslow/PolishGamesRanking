namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreRequirementForce : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GameGenres", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GameGenres", "Name", c => c.String());
        }
    }
}
