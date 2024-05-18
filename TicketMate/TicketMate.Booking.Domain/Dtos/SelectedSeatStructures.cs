using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketMate.Booking.Domain.Dtos
{
    public class SelectedSeatStructures
    {
        public int Id { get; set; }
        public string SeatId { get; set; }
        public bool SeatAvailability { get; set; }

        [ForeignKey("BusId")]
        public int RegisteredBusBusId { get; set; }
        [JsonIgnore]
        public RegisteredBuses? RegisteredBus { get; set; }


    }
}
