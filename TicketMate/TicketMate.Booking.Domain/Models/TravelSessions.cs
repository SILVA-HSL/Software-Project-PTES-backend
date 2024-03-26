using System.ComponentModel.DataAnnotations;

namespace TicketMate.Booking.Api.Models
{
    public class TravelSessions
    {
        [Key]
        public int SessionId { get; set; }
        public String VehicleType { get; set; }
        public String StartLocation { get; set; }
        public String EndLocation { get; set; }
        public String TravelDate { get; set; }
        public String RegNo { get; set; }
        public double Duration { get; set; }
        public double TicketPrice { get; set; }

    }
}
