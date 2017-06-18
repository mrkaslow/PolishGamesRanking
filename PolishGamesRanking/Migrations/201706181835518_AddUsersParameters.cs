namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsersParameters : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "WantNewsletter", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Nick", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.AspNetUsers", "Nick");
            DropColumn("dbo.AspNetUsers", "WantNewsletter");
        }
    }
}
