using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class ScheduledCarriage
    {
        public int Id { get; set; }
        public string ClassType { get; set; }
        public int RegisteredCarriageCarriageId { get; set; }
        public int ScheduledTrainSchedulId { get; set; }

        [JsonIgnore]
        public ScheduledTrain? ScheduledTrain { get; set; }

        [JsonIgnore]
        public RegisteredCarriage? RegisteredCarriage { get; set; }
    }
}
