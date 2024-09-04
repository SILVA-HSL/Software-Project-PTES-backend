using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketMate.Booking.Domain.Dtos
{
    public class SelCarriageSeatStructures
    {
        public int Id { get; set; }
        public string SeatId { get; set; }
        
        public bool Avalability { get; set; }

        public int RegisteredCarriageCarriageId { get; set; }

        [JsonIgnore]
        public RegisteredCarriages? RegisteredCarriage { get; set; }
    }
}
