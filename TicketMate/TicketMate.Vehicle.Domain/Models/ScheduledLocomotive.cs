using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class ScheduledLocomotive
    {
        public int Id { get; set; }
        public ScheduledTrain? ScheduledTrain { get; set; }
        public RegisteredLocomotive? RegisteredLocomotive { get; set; }
    }
}
