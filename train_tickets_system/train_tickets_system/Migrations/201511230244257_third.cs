namespace train_tickets_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "TripRefId", "dbo.Trips");
            DropForeignKey("dbo.Routes", "IntialCity_CityId", "dbo.Cities");
            DropForeignKey("dbo.Routes", "TargetCity_CityId", "dbo.Cities");
            DropForeignKey("dbo.Trips", "RouteRefId", "dbo.Routes");
            DropForeignKey("dbo.Trips", "TrainRefId", "dbo.Trains");
            DropIndex("dbo.Reservations", new[] { "TripRefId" });
            DropIndex("dbo.Trips", new[] { "TrainRefId" });
            DropIndex("dbo.Trips", new[] { "RouteRefId" });
            DropIndex("dbo.Routes", new[] { "IntialCity_CityId" });
            DropIndex("dbo.Routes", new[] { "TargetCity_CityId" });
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            DropTable("dbo.Cities");
            DropTable("dbo.Prices");
            DropTable("dbo.Reservations");
            DropTable("dbo.Trips");
            DropTable("dbo.Routes");
            DropTable("dbo.Trains");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Trains",
                c => new
                    {
                        TrainId = c.Int(nullable: false, identity: true),
                        businessSeats = c.Int(nullable: false),
                        econimicSeats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrainId);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        RouteId = c.Int(nullable: false, identity: true),
                        Value = c.Single(nullable: false),
                        IntialCity_CityId = c.Int(),
                        TargetCity_CityId = c.Int(),
                    })
                .PrimaryKey(t => t.RouteId);
            
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
                .PrimaryKey(t => t.TripId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        Customer_ID = c.Int(nullable: false),
                        TripRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationId);
            
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
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            CreateIndex("dbo.Routes", "TargetCity_CityId");
            CreateIndex("dbo.Routes", "IntialCity_CityId");
            CreateIndex("dbo.Trips", "RouteRefId");
            CreateIndex("dbo.Trips", "TrainRefId");
            CreateIndex("dbo.Reservations", "TripRefId");
            AddForeignKey("dbo.Trips", "TrainRefId", "dbo.Trains", "TrainId", cascadeDelete: true);
            AddForeignKey("dbo.Trips", "RouteRefId", "dbo.Routes", "RouteId", cascadeDelete: true);
            AddForeignKey("dbo.Routes", "TargetCity_CityId", "dbo.Cities", "CityId");
            AddForeignKey("dbo.Routes", "IntialCity_CityId", "dbo.Cities", "CityId");
            AddForeignKey("dbo.Reservations", "TripRefId", "dbo.Trips", "TripId", cascadeDelete: true);
        }
    }
}
