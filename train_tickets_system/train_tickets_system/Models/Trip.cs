﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train_tickets_system.Models
{
    public  class Trip
    {
        public int TripId { get; set; }
        public int TrainRefId { get; set; }
        [ForeignKey("TrainRefId")]
        public virtual Train Train { get; set; }
        public int RouteRefId { get; set; }
        [ForeignKey("RouteRefId")]
        public virtual Route Route { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
    }
}
