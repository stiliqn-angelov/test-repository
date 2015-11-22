using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace train_tickets_system.Models
{
    public class ProjectDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ProjectDBContext() : base("name=ProjectDBContext")
        {
        }

        public System.Data.Entity.DbSet<train_tickets_system.Models.Trip> Trips { get; set; }
        public System.Data.Entity.DbSet<train_tickets_system.Models.Train> Trains { get; set; }
        public System.Data.Entity.DbSet<train_tickets_system.Models.Reservation> Reservations { get; set; }
        public System.Data.Entity.DbSet<train_tickets_system.Models.Price> Price { get; set; }
        public System.Data.Entity.DbSet<train_tickets_system.Models.Route> Routes { get; set; }
        public System.Data.Entity.DbSet<train_tickets_system.Models.City> Cities { get; set; }
    }
}
