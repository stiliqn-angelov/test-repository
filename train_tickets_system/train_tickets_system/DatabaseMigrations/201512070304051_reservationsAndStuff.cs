namespace train_tickets_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservationsAndStuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Confirmed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Confirmed");
        }
    }
}
