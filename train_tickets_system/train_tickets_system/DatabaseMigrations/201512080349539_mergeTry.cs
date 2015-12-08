namespace train_tickets_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mergeTry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "freeKilometers", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "lastPromotionCheck", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "lastPromotionCheck");
            DropColumn("dbo.AspNetUsers", "freeKilometers");
        }
    }
}
