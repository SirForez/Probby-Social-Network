namespace ProbbySocialNetwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Role1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserConnections", "OtherUser_ID", "dbo.Users");
            DropForeignKey("dbo.UserConnections", "TheUser_ID", "dbo.Users");
            DropIndex("dbo.UserConnections", new[] { "OtherUser_ID" });
            DropIndex("dbo.UserConnections", new[] { "TheUser_ID" });
            AddColumn("dbo.Groups", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Hobbies", "Status_ID", c => c.Int());
            AddColumn("dbo.Hobbies", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.UserConnections", "FollowingID", c => c.Int(nullable: false));
            AddColumn("dbo.UserConnections", "FollowerID", c => c.Int(nullable: false));
            AddColumn("dbo.UserConnections", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.UserConnections", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            CreateIndex("dbo.Groups", "ApplicationUser_Id");
            CreateIndex("dbo.Hobbies", "Status_ID");
            CreateIndex("dbo.Hobbies", "ApplicationUser_Id");
            CreateIndex("dbo.UserConnections", "ApplicationUser_Id");
            CreateIndex("dbo.UserConnections", "ApplicationUser_Id1");
            AddForeignKey("dbo.Hobbies", "Status_ID", "dbo.Status", "ID");
            AddForeignKey("dbo.UserConnections", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UserConnections", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Groups", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Hobbies", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.UserConnections", "OtherUser_ID");
            DropColumn("dbo.UserConnections", "TheUser_ID");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Karma = c.Int(nullable: false),
                        ProfilePic = c.String(),
                        NumberOfFollowers = c.Int(nullable: false),
                        NumberOfFollowing = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.UserConnections", "TheUser_ID", c => c.Int());
            AddColumn("dbo.UserConnections", "OtherUser_ID", c => c.Int());
            DropForeignKey("dbo.Hobbies", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Groups", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserConnections", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserConnections", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Hobbies", "Status_ID", "dbo.Status");
            DropIndex("dbo.UserConnections", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.UserConnections", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Hobbies", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Hobbies", new[] { "Status_ID" });
            DropIndex("dbo.Groups", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.UserConnections", "ApplicationUser_Id1");
            DropColumn("dbo.UserConnections", "ApplicationUser_Id");
            DropColumn("dbo.UserConnections", "FollowerID");
            DropColumn("dbo.UserConnections", "FollowingID");
            DropColumn("dbo.Hobbies", "ApplicationUser_Id");
            DropColumn("dbo.Hobbies", "Status_ID");
            DropColumn("dbo.Groups", "ApplicationUser_Id");
            CreateIndex("dbo.UserConnections", "TheUser_ID");
            CreateIndex("dbo.UserConnections", "OtherUser_ID");
            AddForeignKey("dbo.UserConnections", "TheUser_ID", "dbo.Users", "ID");
            AddForeignKey("dbo.UserConnections", "OtherUser_ID", "dbo.Users", "ID");
        }
    }
}
