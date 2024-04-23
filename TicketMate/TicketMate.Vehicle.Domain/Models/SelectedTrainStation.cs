using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class SelectedTrainStation
    {
        public int id { get; set; }
        public string TrainStationName { get; set; }
        public string TrainarrivalTime { get; set; }
        public string TrainDepartureTime { get; set; }
        public ScheduledTrain? ScheduledTrain { get; set; }
    }
}
