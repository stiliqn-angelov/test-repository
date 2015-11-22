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

        public System.Data.Entity.DbSet<train_tickets_system.Models.Schedules> Schedules { get; set; }
        public System.Data.Entity.DbSet<train_tickets_system.Models.Trains> Trains { get; set; }
        public System.Data.Entity.DbSet<train_tickets_system.Models.Reservations> Reservations { get; set; }
        public System.Data.Entity.DbSet<train_tickets_system.Models.Price> Price { get; set; }
        public System.Data.Entity.DbSet<train_tickets_system.Models.Distances> Distances { get; set; }
        public System.Data.Entity.DbSet<train_tickets_system.Models.Cities> Cities { get; set; }
    }
}
