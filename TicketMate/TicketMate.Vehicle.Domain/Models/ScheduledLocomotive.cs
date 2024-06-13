using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class ScheduledLocomotive
    {
        public int Id { get; set; }
        public int ScheduledTrainSchedulId { get; set; }
        public int RegisteredLocomotiveLocomotiveId { get; set; }
        [JsonIgnore]
        public ScheduledTrain? ScheduledTrain { get; set; }
        [JsonIgnore]
        public RegisteredLocomotive? RegisteredLocomotive { get; set; }
    }
}
