using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketMate.Booking.Domain.Dtos
{
    public class RegisteredCarriages
    {
        [Key]
        public int CarriageId { get; set; }
        public string CarriageNo { get; set; }
        public int SeatsCount { get; set; }
     
        public int CarriageClass { get; set; }
        [JsonIgnore]
        public List<SelCarriageSeatStructures>? SelCarriageSeatStructures { get; set; }

        [JsonIgnore]
        public List<ScheduledCarriages>? ScheduledCarriages { get; set; }

    }
}
