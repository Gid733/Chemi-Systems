namespace ChemiSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentTransaction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentTransactions",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        PaymentId = c.String(),
                        UserId = c.Guid(nullable: false),
                        OrderId = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentStatus = c.Int(nullable: false),
                        PaymentAction = c.Int(nullable: false),
                        OperationType = c.Int(nullable: false),
                        ChangedBy = c.Guid(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        ChangedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaymentTransactions");
        }
    }
}
