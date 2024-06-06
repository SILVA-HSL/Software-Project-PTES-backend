using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Booking.Domain.Dtos
{
    public class ScheduledTrainDates
    {
        public int Id { get; set; }
        public string ArrivalDate { get; set; }
        public string DepartureDate { get; set; }

        public int ScheduledTrainSchedulId { get; set; }
        public ScheduledTrains ScheduledTrain { get; set; }

    }
}
