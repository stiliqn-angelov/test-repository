using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train_tickets_system.Models
{
    public class Reservations
    {
        public int ID { get; set; }
        public int Customer_ID { get; set; }
        public List<Cities> InitialCity { get; set; }
        public List<Cities> TargetCity { get; set; }
        //We need a system for calculating travel routes
    }
}
