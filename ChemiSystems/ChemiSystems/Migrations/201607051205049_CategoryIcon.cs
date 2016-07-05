namespace ChemiSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryIcon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategories", "CategoryIcon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductCategories", "CategoryIcon");
        }
    }
}
