namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewStuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "User_Id");
            AddForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropColumn("dbo.Orders", "User_Id");
            DropColumn("dbo.Orders", "UserId");
        }
    }
}
