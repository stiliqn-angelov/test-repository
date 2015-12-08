using System.Collections.Generic;
using train_tickets_system.Models;

namespace train_tickets_system.ViewModels
{
    public class SearchResultViewModel
    {
        public IEnumerable<Trip> Trips { get; set; }

        public int FreeEconomySeats { get; set; }

        public int EconomySeats { get; set; }

        public int FreeBusinessSeats { get; set; }

        public int BusinessSeats { get; set; }
    }
}