using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class ScheduledTrainDate
    {
        public int Id { get; set; }
        public string ArrivalDate { get; set; }
        public string DepartureDate { get; set; }
        public bool IsCompleted { get; set; } = false;
        public ScheduledTrain? ScheduledTrain { get; set; }
    }
}
