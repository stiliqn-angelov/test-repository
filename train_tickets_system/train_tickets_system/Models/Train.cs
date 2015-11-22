using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train_tickets_system.Models
{
    public  class Train
    {
        public int TrainId { get; set; }
        public int businessSeats { get; set; }
        public int econimicSeats { get; set; }
    }
}
