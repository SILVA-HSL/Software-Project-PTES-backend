using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class TrainRaliwayStation
    {
        public int id { get; set; }
        public string TrainStationName { get; set; }
        public TrainRaliway? TrainRaliway { get; set; }
    }
}
