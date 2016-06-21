namespace ChemiSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderStatus", c => c.Int(nullable: false));
            AddColumn("dbo.ProductInOrders", "Amount", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "OrderedBy", c => c.Guid());
            DropColumn("dbo.ProductInOrders", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductInOrders", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "OrderedBy", c => c.Guid(nullable: false));
            DropColumn("dbo.ProductInOrders", "Amount");
            DropColumn("dbo.Orders", "OrderStatus");
        }
    }
}
