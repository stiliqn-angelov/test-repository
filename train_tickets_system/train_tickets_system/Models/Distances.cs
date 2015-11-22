using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train_tickets_system.Models
{
    public  class Distances
    {  
        public int ID { get; set; }
        public List<Cities> InitialCityID { get; set; }
        public List<Cities> TargetCityID { get; set; }
        public float Value { get; set; }
    }
}
