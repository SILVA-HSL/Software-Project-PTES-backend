using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Booking.Application.Dtos;

namespace TicketMate.Booking.Domain.Dtos
{
    public class BusScheduleDetails
    {
        List<ScheduledBuses> ScheduledBuses { get; set; }
        List<SelectedBusStands> SelectedBusStands { get; set; }

        List<ScheduledBusDates> ScheduledBusDates { get; set; }
    }
}
