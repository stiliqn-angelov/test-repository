namespace train_tickets_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Routes", "City_CityId", "dbo.Cities");
            DropIndex("dbo.Routes", new[] { "City_CityId" });
            DropColumn("dbo.Routes", "City_CityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Routes", "City_CityId", c => c.Int());
            CreateIndex("dbo.Routes", "City_CityId");
            AddForeignKey("dbo.Routes", "City_CityId", "dbo.Cities", "CityId");
        }
    }
}
