using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Reporting.Domain.Models
{
    [Table("ScheduledBusDates")]
    public class ScheduledBusDate
    {
        public int Id { get; set; }

        [ForeignKey("ScheduleId")]
        public int ScheduledBusScheduleId { get; set; }
        public string ArrivalDate { get; set; }
        public string DepartureDate { get; set; }

        public bool IsCompleted { get; set; } = false;

        //[JsonIgnore]
        //public ScheduledBus? ScheduledBus { get; set; }

    }
}
