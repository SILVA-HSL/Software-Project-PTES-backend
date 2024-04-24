using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Booking.Domain.Dtos
{
    public class RegisteredBusDetails
    {
        public RegisteredBuses RegisteredBus { get; set; }
        public List<SelectedSeatStructures> SelectedSeatStructures { get; set; }
    }
}
