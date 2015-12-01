using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace train_tickets_system.Models
{
    public class Reservation
    {
        public Reservation() { }
        public int ReservationId { get; set; }
        public String CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public ApplicationUser User { get; set; }
       
        public int TripRefId { get; set; }
        [ForeignKey("TripRefId")]
        public virtual Trip Trip { get; set; }
        //We need a system for calculating travel routes
    }
}
