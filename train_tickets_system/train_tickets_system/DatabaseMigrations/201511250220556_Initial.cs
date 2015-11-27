namespace train_tickets_system.DatabaseMigrations
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
                        TripRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.Trips", t => t.TripRefId, cascadeDelete: true)
                .Index(t => t.TripRefId);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        TripId = c.Int(nullable: false, identity: true),
                        TrainRefId = c.Int(nullable: false),
                        RouteRefId = c.Int(nullable: false),
                        DepartureTime = c.DateTime(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TripId)
                .ForeignKey("dbo.Routes", t => t.RouteRefId, cascadeDelete: true)
                .ForeignKey("dbo.Trains", t => t.TrainRefId, cascadeDelete: true)
                .Index(t => t.TrainRefId)
                .Index(t => t.RouteRefId);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        RouteId = c.Int(nullable: false, identity: true),
                        Value = c.Single(nullable: false),
                        IntialCity_CityId = c.Int(),
                        TargetCity_CityId = c.Int(),
                    })
                .PrimaryKey(t => t.RouteId)
                .ForeignKey("dbo.Cities", t => t.IntialCity_CityId)
                .ForeignKey("dbo.Cities", t => t.TargetCity_CityId)
                .Index(t => t.IntialCity_CityId)
                .Index(t => t.TargetCity_CityId);
            
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
            DropForeignKey("dbo.Trips", "TrainRefId", "dbo.Trains");
            DropForeignKey("dbo.Trips", "RouteRefId", "dbo.Routes");
            DropForeignKey("dbo.Routes", "TargetCity_CityId", "dbo.Cities");
            DropForeignKey("dbo.Routes", "IntialCity_CityId", "dbo.Cities");
            DropForeignKey("dbo.Reservations", "TripRefId", "dbo.Trips");
            DropIndex("dbo.Routes", new[] { "TargetCity_CityId" });
            DropIndex("dbo.Routes", new[] { "IntialCity_CityId" });
            DropIndex("dbo.Trips", new[] { "RouteRefId" });
            DropIndex("dbo.Trips", new[] { "TrainRefId" });
            DropIndex("dbo.Reservations", new[] { "TripRefId" });
            DropTable("dbo.Trains");
            DropTable("dbo.Routes");
            DropTable("dbo.Trips");
            DropTable("dbo.Reservations");
            DropTable("dbo.Prices");
            DropTable("dbo.Cities");
        }
    }
}
