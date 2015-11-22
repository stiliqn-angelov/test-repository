namespace train_tickets_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inital : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Reservations", name: "TripId", newName: "TripRefId");
            RenameColumn(table: "dbo.Trips", name: "RouteId", newName: "RouteRefId");
            RenameColumn(table: "dbo.Trips", name: "TrainId", newName: "TrainRefId");
            RenameColumn(table: "dbo.Routes", name: "InitialCity_CityId", newName: "IntialCity_CityId");
            RenameIndex(table: "dbo.Routes", name: "IX_InitialCity_CityId", newName: "IX_IntialCity_CityId");
            RenameIndex(table: "dbo.Trips", name: "IX_TrainId", newName: "IX_TrainRefId");
            RenameIndex(table: "dbo.Trips", name: "IX_RouteId", newName: "IX_RouteRefId");
            RenameIndex(table: "dbo.Reservations", name: "IX_TripId", newName: "IX_TripRefId");
            AddColumn("dbo.Routes", "City_CityId", c => c.Int());
            CreateIndex("dbo.Routes", "City_CityId");
            AddForeignKey("dbo.Routes", "City_CityId", "dbo.Cities", "CityId");
            DropColumn("dbo.Routes", "IntialCityID");
            DropColumn("dbo.Routes", "TargetCityID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Routes", "TargetCityID", c => c.Int(nullable: false));
            AddColumn("dbo.Routes", "IntialCityID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Routes", "City_CityId", "dbo.Cities");
            DropIndex("dbo.Routes", new[] { "City_CityId" });
            DropColumn("dbo.Routes", "City_CityId");
            RenameIndex(table: "dbo.Reservations", name: "IX_TripRefId", newName: "IX_TripId");
            RenameIndex(table: "dbo.Trips", name: "IX_RouteRefId", newName: "IX_RouteId");
            RenameIndex(table: "dbo.Trips", name: "IX_TrainRefId", newName: "IX_TrainId");
            RenameIndex(table: "dbo.Routes", name: "IX_IntialCity_CityId", newName: "IX_InitialCity_CityId");
            RenameColumn(table: "dbo.Routes", name: "IntialCity_CityId", newName: "InitialCity_CityId");
            RenameColumn(table: "dbo.Trips", name: "TrainRefId", newName: "TrainId");
            RenameColumn(table: "dbo.Trips", name: "RouteRefId", newName: "RouteId");
            RenameColumn(table: "dbo.Reservations", name: "TripRefId", newName: "TripId");
        }
    }
}
