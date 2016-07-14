namespace ChemiSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedbackValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Feedbacks", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Feedbacks", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Feedbacks", "Content", c => c.String());
            AlterColumn("dbo.Feedbacks", "Email", c => c.String());
        }
    }
}
