using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class ScheduledBus
    {
        public string ScheduleId {  get; set; }
        public int BusId { get; set; }
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

        // Navigation property for SelectedBusStand
        public SelectedBusStand SelectedBusStand { get; set; }
        public List<SelectedBusStand> SelectedBusStands { get; set; }
        public ScheduledBusDate ScheduledBusDate { get; set; }
        public List<ScheduledBusDate> ScheduledBusDates { get; set; }
    }
}
