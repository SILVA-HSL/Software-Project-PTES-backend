using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class BusRouteStand
    {
        public int id { get; set; }
        public string StandName { get; set; }
        public BusRoute? BusRoute { get; set; }
    }
}
