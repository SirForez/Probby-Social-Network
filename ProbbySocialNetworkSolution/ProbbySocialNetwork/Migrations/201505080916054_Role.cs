namespace ProbbySocialNetwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Role : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Role", c => c.String());
            AddColumn("dbo.AspNetUsers", "Karma", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "ProfilePic", c => c.String());
            AddColumn("dbo.AspNetUsers", "NumberOfFollowers", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "NumberOfFollowing", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "NumberOfFollowing");
            DropColumn("dbo.AspNetUsers", "NumberOfFollowers");
            DropColumn("dbo.AspNetUsers", "ProfilePic");
            DropColumn("dbo.AspNetUsers", "Karma");
            DropColumn("dbo.AspNetUsers", "Role");
        }
    }
}
