namespace ProbbySocialNetwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "StatusID", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "UserID", c => c.String());
            AddColumn("dbo.Status", "UserID", c => c.String());
            AddColumn("dbo.Status", "GroupID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Status", "GroupID");
            DropColumn("dbo.Status", "UserID");
            DropColumn("dbo.Comments", "UserID");
            DropColumn("dbo.Comments", "StatusID");
        }
    }
}
