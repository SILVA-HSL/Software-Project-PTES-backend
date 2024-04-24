using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TicketMate.Booking.Application.Dtos;

namespace TicketMate.Booking.Domain.Dtos
{
    public class ScheduledBuses
    {
        [Key]
        public int ScheduleId { get; set; }
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

      
        public List<SelectedBusStands> SelectedBusStands { get; set; }           
       
        public List<ScheduledBusDates> ScheduledBusDatesList { get; set; }

        
        public RegisteredBuses RegisteredBus { get; set; }
    }
}
