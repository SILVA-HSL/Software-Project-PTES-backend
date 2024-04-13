using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class SelectedBusStand
    {
        public string ScheduleId { get; set; }
        public string BusStation {  get; set; }

        // Foreign key property referencing ScheduledBus
        public ScheduledBus ScheduledBus { get; set; }
    }
}
