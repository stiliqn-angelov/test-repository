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
        //public int RouteId { get; set; }
        [Key]
        public int RouteId { get; set; }
       /* public int InitialCityId { get; set; }
        [ForeignKey("InitialCityId")]*/
        public virtual City IntialCity { get; set; }
       /* public int TargetCityId { get; set; }
        [ForeignKey("TargetCityId")]*/
        public virtual City TargetCity { get; set; }
        public float Value { get; set; }
        public virtual List<Trip> Trips { get; set; }
    }
}
