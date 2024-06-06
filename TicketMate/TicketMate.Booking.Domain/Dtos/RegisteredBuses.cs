using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketMate.Booking.Domain.Dtos
{
    public class RegisteredBuses
    {
        [Key]
        public int BusId { get; set; }

        public int SetsCount { get; set; }
        public bool ACorNONAC { get; set; }

        [JsonIgnore]
        public List<SelectedSeatStructures> SelectedSeatStructures { get; set; }
        [JsonIgnore]
        public List<ScheduledBuses> ScheduledBuses { get; set; }
    }
}
