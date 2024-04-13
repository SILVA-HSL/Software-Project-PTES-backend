using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class ScheduledBusDate
    {
        public string ScheduleId { get; set; }
        public string ScheduleDate { get; set; }

        public ScheduledBus ScheduledBus { get; set; }
    }
}
