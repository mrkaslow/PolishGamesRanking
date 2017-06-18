namespace PolishGamesRanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'65e2cc19-0739-4b15-9d62-803b15b3bf5e', N'kaslowinski@gmail.com', 0, N'AHqbYl3jreBFn5I1HkxmEBkWhIvMBkTnxO2iThQ3Ru0gyD3jgW0w6/q1JGW1n2ZcVQ==', N'327698fc-961f-4beb-95cb-73281e41dffc', NULL, 0, 0, NULL, 1, 0, N'kaslowinski@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c646ffa7-f140-410f-8da1-25bd7751bbb8', N'CanDeleteAndEditGames')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'65e2cc19-0739-4b15-9d62-803b15b3bf5e', N'c646ffa7-f140-410f-8da1-25bd7751bbb8')
");
        }
        
        public override void Down()
        {
        }
    }
}
