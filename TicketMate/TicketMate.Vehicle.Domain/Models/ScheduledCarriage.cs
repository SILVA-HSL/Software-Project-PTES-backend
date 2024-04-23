using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class ScheduledCarriage
    {
        public int Id { get; set; }
        public string ClassType { get; set; }
        public ScheduledTrain? ScheduledTrain { get; set; }
        public RegisteredCarriage? RegisteredCarriage { get; set; }
    }
}
