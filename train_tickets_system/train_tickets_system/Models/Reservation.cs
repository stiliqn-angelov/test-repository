using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train_tickets_system.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int Customer_ID { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        //We need a system for calculating travel routes
    }
}
