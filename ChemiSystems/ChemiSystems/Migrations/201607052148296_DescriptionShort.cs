namespace ChemiSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescriptionShort : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "DescriptionShort", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "DescriptionShort");
        }
    }
}
