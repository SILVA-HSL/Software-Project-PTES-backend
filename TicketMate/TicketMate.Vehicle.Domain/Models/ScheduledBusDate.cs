using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class ScheduledBusDate
    {
        public int Id { get; set; }

        [ForeignKey("ScheduleId")]
        public int ScheduledBusScheduleId { get; set; }
        public string ArrivalDate { get; set; }
        public string DepartureDate { get; set; }

        [JsonIgnore]
        public ScheduledBus? ScheduledBus { get; set; }
    }
}
