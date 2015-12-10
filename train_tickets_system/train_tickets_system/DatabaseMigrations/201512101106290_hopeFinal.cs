namespace train_tickets_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hopeFinal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "PriceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservations", "PriceId");
            AddForeignKey("dbo.Reservations", "PriceId", "dbo.Prices", "PriceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "PriceId", "dbo.Prices");
            DropIndex("dbo.Reservations", new[] { "PriceId" });
            DropColumn("dbo.Reservations", "PriceId");
        }
    }
}
