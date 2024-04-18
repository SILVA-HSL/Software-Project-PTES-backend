using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Booking.Domain.Dtos
{
    public class ScheduledBusDates
    {
        public int Id { get; set; }
        public string ScheduleDate { get; set; }

        // Foreign key to link to ScheduledBuses
        public string ScheduledBusScheduleId { get; set; } 
        public ScheduledBuses ScheduledBus { get; set; }

    }
}
