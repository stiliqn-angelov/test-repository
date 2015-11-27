namespace train_tickets_system.DatabaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewSeed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trains", "businessSeatsTaken", c => c.Int(nullable: false));
            AddColumn("dbo.Trains", "econimicSeatsTaken", c => c.Int(nullable: false));
            AddColumn("dbo.Trains", "AverageSpeed", c => c.Single(nullable: false));
            AlterColumn("dbo.Prices", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Prices", "Value", c => c.Single(nullable: false));
            DropColumn("dbo.Trains", "AverageSpeed");
            DropColumn("dbo.Trains", "econimicSeatsTaken");
            DropColumn("dbo.Trains", "businessSeatsTaken");
        }
    }
}
