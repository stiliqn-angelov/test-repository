namespace train_tickets_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Distances_ID = c.Int(),
                        Distances_ID1 = c.Int(),
                        Reservations_ID = c.Int(),
                        Reservations_ID1 = c.Int(),
                        Schedules_ID = c.Int(),
                        Schedules_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Distances", t => t.Distances_ID)
                .ForeignKey("dbo.Distances", t => t.Distances_ID1)
                .ForeignKey("dbo.Reservations", t => t.Reservations_ID)
                .ForeignKey("dbo.Reservations", t => t.Reservations_ID1)
                .ForeignKey("dbo.Schedules", t => t.Schedules_ID)
                .ForeignKey("dbo.Schedules", t => t.Schedules_ID1)
                .Index(t => t.Distances_ID)
                .Index(t => t.Distances_ID1)
                .Index(t => t.Reservations_ID)
                .Index(t => t.Reservations_ID1)
                .Index(t => t.Schedules_ID)
                .Index(t => t.Schedules_ID1);
            
            CreateTable(
                "dbo.Distances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Customer_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DepartureTime = c.DateTime(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Trains",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        business_seats = c.Int(nullable: false),
                        econimic_seats = c.Int(nullable: false),
                        Schedules_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Schedules", t => t.Schedules_ID)
                .Index(t => t.Schedules_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trains", "Schedules_ID", "dbo.Schedules");
            DropForeignKey("dbo.Cities", "Schedules_ID1", "dbo.Schedules");
            DropForeignKey("dbo.Cities", "Schedules_ID", "dbo.Schedules");
            DropForeignKey("dbo.Cities", "Reservations_ID1", "dbo.Reservations");
            DropForeignKey("dbo.Cities", "Reservations_ID", "dbo.Reservations");
            DropForeignKey("dbo.Cities", "Distances_ID1", "dbo.Distances");
            DropForeignKey("dbo.Cities", "Distances_ID", "dbo.Distances");
            DropIndex("dbo.Trains", new[] { "Schedules_ID" });
            DropIndex("dbo.Cities", new[] { "Schedules_ID1" });
            DropIndex("dbo.Cities", new[] { "Schedules_ID" });
            DropIndex("dbo.Cities", new[] { "Reservations_ID1" });
            DropIndex("dbo.Cities", new[] { "Reservations_ID" });
            DropIndex("dbo.Cities", new[] { "Distances_ID1" });
            DropIndex("dbo.Cities", new[] { "Distances_ID" });
            DropTable("dbo.Trains");
            DropTable("dbo.Schedules");
            DropTable("dbo.Reservations");
            DropTable("dbo.Prices");
            DropTable("dbo.Distances");
            DropTable("dbo.Cities");
        }
    }
}
