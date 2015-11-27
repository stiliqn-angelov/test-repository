using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train_tickets_system.Models
{
    public  class Route
    {  
        public Route() { }
        public Route(int id, City icity, City tcity, float value)
        {
            RouteId = id;
            IntialCity = icity;
            TargetCity = tcity;
            this.Value = value;
        }
        //public int RouteId { get; set; }
        [Key]
        public int RouteId { get; set; }
        public virtual City IntialCity { get; set; }
        public virtual City TargetCity { get; set; }
        public float Value { get; set; }//kilometers
        public virtual List<Trip> Trips { get; set; }
    }
}
