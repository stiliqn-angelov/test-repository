using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train_tickets_system.Models
{
    public  class Trip
    {
        public int TripId { get; set; }
        public int TrainId { get; set; }
        public int RouteId { get; set; }
        public Train Train { get; set; }
        public Route Route { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public List<Reservation> ReservationId { get; set; }
    }
}
