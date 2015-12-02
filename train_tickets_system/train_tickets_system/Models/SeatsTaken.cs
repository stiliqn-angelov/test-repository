using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train_tickets_system.Models
{
    public class SeatsTaken
    {
        [Key, ForeignKey("Trip")]
        public int TripId { get; set; }
        public int Value { get; set; }
        public Trip Trip { get; set; }

    }
}
