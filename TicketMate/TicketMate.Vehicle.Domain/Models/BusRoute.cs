using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class BusRoute
    {
        [Key]
        public int RoutId { get; set; }
        public string RoutNo { get; set; }
        public string StartStand { get; set; }
        public string EndStand { get; set; }
        [JsonIgnore]
        public List<BusRouteStand>? BusRouteStands { get; set; }
    }
}
