namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAndRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd3133896-2032-472c-a19b-a735c5631612', N'canManageMovies')

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'123f61c2-d4ed-408c-a5c9-501c1a0e8c10', N'admin@vidly.com', 0, N'AOKER69jHcFDeWIfqZzHGBg7MJn32ZJbmhZJVnuKHC2kXnaW58VVn14CbmnS/e8oCg==', N'6bb0df80-35c6-4ca6-84bf-35a510e24aef', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'47622428-6ac1-429e-b890-7baf6caffcc8', N'guest@vidly.com', 0, N'AEIxOl9eOx5tT+bQ8jxmD4uv3rcV1jwGa8V/6Ss/1naC2QyNfwi3MWOUpk4t9lrjog==', N'b889520b-0052-423f-9cdd-42cd669f4603', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'123f61c2-d4ed-408c-a5c9-501c1a0e8c10', N'd3133896-2032-472c-a19b-a735c5631612')

");
        }
        
        public override void Down()
        {
        }
    }
}
