using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class RegisteredLocomotive
    {
        [Key]
        public int LocomotiveId { get; set; }
        public string LocomotiveNumber { get; set; }
        public string LocomotiveType { get; set; }
        public string LocomotiveModel { get; set; }
        public string LocomotiveCapacity { get; set; }
        public string LocomotiveSpeed { get; set; }

        [JsonIgnore]
        public List<ScheduledLocomotive>? ScheduledLocomotives { get; set; }
    }
}
