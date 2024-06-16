using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Reporting.Domain.Models
{
    public class ScheduledBuses
    {
        [Key]
        public int ScheduleId { get; set; }

        [ForeignKey("BusId")]
        public int RegisteredBusBusId { get; set; }
        public string BusNo { get; set; }
        public int DriverId { get; set; }
        public string RoutNo { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        //public DateTime TravelDate { get; set; }
        public string Comfortability { get; set; }
        public string Duration { get; set; }
        public decimal TicketPrice { get; set; }

        public string UserId { get; set; }
        public bool DeleteState { get; set; } = true;

        //[JsonIgnore]
        //public List<SelectedBusStand>? SelectedBusStands { get; set; }

        //[JsonIgnore]
        //public List<ScheduledBusDate>? ScheduledBusDates { get; set; }

        //[JsonIgnore]
        //public RegisteredBus? RegisteredBus { get; set; }

    }
}
