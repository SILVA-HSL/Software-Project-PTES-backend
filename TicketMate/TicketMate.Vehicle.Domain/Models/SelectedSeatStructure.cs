using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TicketMate.Vehicle.API.Models;

namespace TicketMate.Vehicle.Domain.Models
{
    public class SelectedSeatStructure
    {
        public int Id { get; set; }
        public int SeatId { get; set; }
        public bool SeatAvailability { get; set; }

        [ForeignKey("BusId")]
        public int RegisteredBusBusId { get; set; }
        [JsonIgnore]
        public RegisteredBus? RegisteredBus { get; set; }
    }
}
