using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class TrainRaliway
    {
        public int Id { get; set; }
        public int RailwayNo { get; set; }
        public string RailwayName { get; set; }
        public string StartStation { get; set; }
        public string EndStation { get; set; }

        [JsonIgnore]
        public List<TrainRaliwayStation>? TrainRaliwayStations { get; set; }
    }
}
