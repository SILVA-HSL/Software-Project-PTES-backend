using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Booking.Domain.Dtos
{
    public class BusFeedbackDto
    {
        public int BusId { get; set; }
        public int BookingId { get; set; }
        public string PassengerId { get; set; }
        public decimal Rate { get; set; }
        public string FeedBack { get; set; }
        public string GivenDate { get; set; }
    }
}
