namespace ChemiSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        DeliverToDate = c.DateTime(),
                        DeliverToAddress = c.String(),
                        OrderedBy = c.String(),
                        TotalPrice = c.Double(nullable: false),
                        OrderStatusId = c.Guid(nullable: false),
                        ChangedBy = c.Guid(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        ChangedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatusId, cascadeDelete: true)
                .Index(t => t.OrderStatusId);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Status = c.String(),
                        StatusColor = c.String(),
                        StatusIcon = c.String(),
                        ChangedBy = c.Guid(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        ChangedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductInOrders",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        VendorCode = c.String(),
                        DescriptionMain = c.String(),
                        DescriptionSecondary = c.String(),
                        Price = c.Double(nullable: false),
                        Amount = c.Int(nullable: false),
                        ProductImageId = c.Guid(nullable: false),
                        ProductCategoryId = c.Guid(nullable: false),
                        ChangedBy = c.Guid(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        ChangedDate = c.DateTime(),
                        Order_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.ProductImages", t => t.ProductImageId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.ProductImageId)
                .Index(t => t.ProductCategoryId)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        ChangedBy = c.Guid(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        ChangedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        VendorCode = c.String(),
                        DescriptionMain = c.String(),
                        DescriptionSecondary = c.String(),
                        Price = c.Double(nullable: false),
                        ProductImageId = c.Guid(nullable: false),
                        ProductCategoryId = c.Guid(nullable: false),
                        ChangedBy = c.Guid(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        ChangedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.ProductImages", t => t.ProductImageId, cascadeDelete: true)
                .Index(t => t.ProductImageId)
                .Index(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ImageMain = c.String(),
                        ImageMolecular = c.String(),
                        ImageFormula = c.String(),
                        ChangedBy = c.Guid(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        ChangedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductInOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ProductInOrders", "ProductImageId", "dbo.ProductImages");
            DropForeignKey("dbo.ProductInOrders", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.Products", "ProductImageId", "dbo.ProductImages");
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.Orders", "OrderStatusId", "dbo.OrderStatus");
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            DropIndex("dbo.Products", new[] { "ProductImageId" });
            DropIndex("dbo.ProductInOrders", new[] { "Order_Id" });
            DropIndex("dbo.ProductInOrders", new[] { "ProductCategoryId" });
            DropIndex("dbo.ProductInOrders", new[] { "ProductImageId" });
            DropIndex("dbo.Orders", new[] { "OrderStatusId" });
            DropTable("dbo.ProductImages");
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.ProductInOrders");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Orders");
        }
    }
}
