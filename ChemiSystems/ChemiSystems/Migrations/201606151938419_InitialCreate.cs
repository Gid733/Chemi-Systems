namespace ChemiSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        OrderedBy = c.Guid(nullable: false),
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
                        Quantity = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Country = c.String(),
                        Street = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProductInOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ProductInOrders", "ProductImageId", "dbo.ProductImages");
            DropForeignKey("dbo.ProductInOrders", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.Products", "ProductImageId", "dbo.ProductImages");
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            DropIndex("dbo.Products", new[] { "ProductImageId" });
            DropIndex("dbo.ProductInOrders", new[] { "Order_Id" });
            DropIndex("dbo.ProductInOrders", new[] { "ProductCategoryId" });
            DropIndex("dbo.ProductInOrders", new[] { "ProductImageId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.ProductInOrders");
            DropTable("dbo.Orders");
        }
    }
}
