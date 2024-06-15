using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class BusRouteStand
    {
        public int Id { get; set; }
        public string StandName { get; set; }

        public int BusRouteRoutId { get; set; }

        [JsonIgnore]
        public BusRoute? BusRoute { get; set; }
    }
}
