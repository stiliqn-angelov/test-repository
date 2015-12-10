namespace train_tickets_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nextONe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SeatsTakens", "SeatsEconomical", c => c.Int(nullable: false));
            AddColumn("dbo.SeatsTakens", "SeatsBusiness", c => c.Int(nullable: false));
            DropColumn("dbo.SeatsTakens", "Value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SeatsTakens", "Value", c => c.Int(nullable: false));
            DropColumn("dbo.SeatsTakens", "SeatsBusiness");
            DropColumn("dbo.SeatsTakens", "SeatsEconomical");
        }
    }
}
