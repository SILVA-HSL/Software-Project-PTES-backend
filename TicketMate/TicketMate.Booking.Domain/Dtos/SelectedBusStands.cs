
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Booking.Domain.Dtos;

namespace TicketMate.Booking.Application.Dtos
{
    public class SelectedBusStands
    {
        [Key]
        public int Id { get; set; }
        public string BusStation { get; set; }

        // Foreign key to link to ScheduledBuses
        public int ScheduledBusScheduleId { get; set; }

        public string StandArrivalTime { get; set; }
        public ScheduledBuses ScheduledBus { get; set; }
    }
}



