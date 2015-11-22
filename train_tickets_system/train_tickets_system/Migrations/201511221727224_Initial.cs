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
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        RouteId = c.Int(nullable: false, identity: true),
                        IntialCityID = c.Int(nullable: false),
                        TargetCityID = c.Int(nullable: false),
                        Value = c.Single(nullable: false),
                        InitialCity_CityId = c.Int(),
                        TargetCity_CityId = c.Int(),
                    })
                .PrimaryKey(t => t.RouteId)
                .ForeignKey("dbo.Cities", t => t.InitialCity_CityId)
                .ForeignKey("dbo.Cities", t => t.TargetCity_CityId)
                .Index(t => t.InitialCity_CityId)
                .Index(t => t.TargetCity_CityId);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        PriceId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.PriceId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        Customer_ID = c.Int(nullable: false),
                        TripId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.Trips", t => t.TripId, cascadeDelete: true)
                .Index(t => t.TripId);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        TripId = c.Int(nullable: false, identity: true),
                        TrainId = c.Int(nullable: false),
                        RouteId = c.Int(nullable: false),
                        DepartureTime = c.DateTime(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TripId)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .ForeignKey("dbo.Trains", t => t.TrainId, cascadeDelete: true)
                .Index(t => t.TrainId)
                .Index(t => t.RouteId);
            
            CreateTable(
                "dbo.Trains",
                c => new
                    {
                        TrainId = c.Int(nullable: false, identity: true),
                        businessSeats = c.Int(nullable: false),
                        econimicSeats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrainId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trips", "TrainId", "dbo.Trains");
            DropForeignKey("dbo.Trips", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.Reservations", "TripId", "dbo.Trips");
            DropForeignKey("dbo.Routes", "TargetCity_CityId", "dbo.Cities");
            DropForeignKey("dbo.Routes", "InitialCity_CityId", "dbo.Cities");
            DropIndex("dbo.Trips", new[] { "RouteId" });
            DropIndex("dbo.Trips", new[] { "TrainId" });
            DropIndex("dbo.Reservations", new[] { "TripId" });
            DropIndex("dbo.Routes", new[] { "TargetCity_CityId" });
            DropIndex("dbo.Routes", new[] { "InitialCity_CityId" });
            DropTable("dbo.Trains");
            DropTable("dbo.Trips");
            DropTable("dbo.Reservations");
            DropTable("dbo.Prices");
            DropTable("dbo.Routes");
            DropTable("dbo.Cities");
        }
    }
}
