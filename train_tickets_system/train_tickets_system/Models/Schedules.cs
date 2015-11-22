using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train_tickets_system.Models
{
    public  class Schedules
    {
        public int ID { get; set; }
        public List<Trains> TrainID { get; set; }
        public List<Cities> DepartureCityID { get; set; }
        public List<Cities> ArrivalCityID { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
