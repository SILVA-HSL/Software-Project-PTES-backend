using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Booking.Domain.Dtos
{
    public class RegisteredBusDetails
    {
        //This schema is created to store the details of the registered bus with the selected seats. This is a
        //combination of 2 tables RegisteredBuses and SelectedSeatStructures
        public RegisteredBuses RegisteredBus { get; set; }
        public List<SelectedSeatStructures> SelectedSeatStructures { get; set; }
    }
}
