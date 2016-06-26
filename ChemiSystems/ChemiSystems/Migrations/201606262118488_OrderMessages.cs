namespace ChemiSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderMessages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderMessages",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Content = c.String(),
                        UserId = c.Guid(nullable: false),
                        DateSend = c.DateTime(),
                        Order_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderMessages", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderMessages", new[] { "Order_Id" });
            DropTable("dbo.OrderMessages");
        }
    }
}
