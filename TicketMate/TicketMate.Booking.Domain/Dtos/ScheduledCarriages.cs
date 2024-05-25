using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Booking.Domain.Dtos
{
    public class ScheduledCarriages
    {
        public int Id { get; set; }
        public string ClassType { get; set; }

        public int ScheduledTrainSchedulId { get; set; }

        public int RegisteredCarriageCarriageId { get; set; }
        public ScheduledTrains? ScheduledTrain { get; set; }
        public RegisteredCarriages? RegisteredCarriage { get; set; }
    }
}
