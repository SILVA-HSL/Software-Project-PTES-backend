using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Booking.Domain.Dtos
{
    public class RegisteredTrainDetails
    {
       // public ScheduledTrains ScheduledTrain { get; set; }
        public List<ScheduledCarriages> ScheduledCarriages { get; set; }
        public List<RegisteredCarriages> RegisteredCarriages { get; set; }
        public List<SelCarriageSeatStructures> SelCarriageSeatStructures { get; set; }
    }   
}
