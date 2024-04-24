using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Booking.Domain.Dtos
{
    public class SelectedTrainStations
    {
        public int id { get; set; }
        public string TrainStationName { get; set; }
        public string TrainarrivalTime { get; set; }
        public string TrainDepartureTime { get; set; }

        public int ScheduledTrainSchedulId { get; set; }
        public ScheduledTrains ScheduledTrain { get; set; }

        
       // public ScheduledTrainDates ScheduledTrainDates { get; set; }


    }
}
