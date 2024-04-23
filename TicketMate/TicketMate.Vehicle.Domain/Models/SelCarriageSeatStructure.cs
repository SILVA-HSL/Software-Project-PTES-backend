using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class SelCarriageSeatStructure
    {
        public int Id { get; set; }
        public int SeatId { get; set; }
        //public int CarriageId { get; set; }
        public bool Avalability { get; set; }

        [JsonIgnore]
        public RegisteredCarriage? RegisteredCarriage { get; set; }
    }
}
