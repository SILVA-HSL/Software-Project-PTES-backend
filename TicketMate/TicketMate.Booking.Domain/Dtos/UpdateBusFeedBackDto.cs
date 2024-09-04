using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Booking.Domain.Dtos
{
    public class UpdateBusFeedBackDto
    {
        public string feedback { get; set; }
        public decimal rate { get; set; }
    }
}
