using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketMate.Reporting.Domain.Models
{
    public class ScheduledTrain
    {
        [Key]
        public int SchedulId { get; set; }
        public int TrainDriverId { get; set; }
        public string TrainRoutNo { get; set; }
        public string TrainName { get; set; }
        public string StartStation { get; set; }
        public string EndStation { get; set; }
        public string TrainDepartureTime { get; set; }
        public string TrainArrivalTime { get; set; }
        public string Duration { get; set; }
        public string TrainType { get; set; }
        public decimal FirstClassTicketPrice { get; set; }
        public decimal SecondClassTicketPrice { get; set; }
        public string UserId { get; set; }
        public bool DeleteState { get; set; } = true;

        //[JsonIgnore]
        //public List<ScheduledCarriage>? ScheduledCarriages { get; set; }
        //[JsonIgnore]
        //public List<ScheduledLocomotive>? ScheduledLocomotives { get; set; }

        //[JsonIgnore]
        //public List<ScheduledTrainDate>? ScheduledTrainDates { get; set; }

        //[JsonIgnore]
        //public List<SelectedTrainStation>? SelectedTrainStations { get; set; }
    }

}
