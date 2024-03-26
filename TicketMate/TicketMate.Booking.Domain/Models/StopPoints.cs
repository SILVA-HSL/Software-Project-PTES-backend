using System.ComponentModel.DataAnnotations;

namespace TicketMate.Booking.Api.Models
{
    public class StopPoints
    {
        [Key]
        public int StopId { get; set; }
        public string StopName { get; set; }
    }
}
