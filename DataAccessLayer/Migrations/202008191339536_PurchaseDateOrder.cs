namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseDateOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PurchaseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PurchaseDate");
        }
    }
}
