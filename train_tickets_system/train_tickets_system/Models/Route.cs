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
        public int RouteId { get; set; }
        public int IntialCityID { get; set; }
        public int TargetCityID { get; set; }
        public City InitialCity { get; set; }
        public City TargetCity { get; set; }
        public float Value { get; set; }
    }
}
