using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TicketMate.Vehicle.API.Models;

namespace TicketMate.Vehicle.Domain.Models
{
    public class ScheduledBus
    {
        [Key]
        public string ScheduleId {  get; set; }

        [ForeignKey("BusId")]
        public int RegisteredBusBusId { get; set; }
        public string BusNo { get; set; }
        public int DriverId { get; set; }
        public string RoutNo { get; set; }
        public string StartLocation {  get; set; }
        public string EndLocation { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        //public DateTime TravelDate { get; set; }
        public string Comfortability { get; set; }
        public string Duration { get; set; }
        public decimal TicketPrice { get; set; }

        [JsonIgnore]
        public List<SelectedBusStand>? SelectedBusStands { get; set; }
        
        [JsonIgnore]
        public List<ScheduledBusDate>? ScheduledBusDates { get; set; }

        [JsonIgnore]
        public RegisteredBus? RegisteredBus { get; set; }
    }
}
