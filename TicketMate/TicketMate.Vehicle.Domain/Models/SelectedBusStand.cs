using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class SelectedBusStand
    {
        public int Id { get; set; }

        [ForeignKey("ScheduleId")]
        public string ScheduledBusScheduleId { get; set; }
        public string BusStation {  get; set; }
        public string StandArrivalTime { get; set; }

        // Foreign key property referencing ScheduledBus
        [JsonIgnore]
        public ScheduledBus? ScheduledBus { get; set; }
    }
}
