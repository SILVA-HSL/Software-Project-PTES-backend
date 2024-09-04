using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Booking.Domain.Models
{
    public class TrainFeedBack
    {
        [Key]
        public int FeedBackId { get; set; }

        public int TrainScheduleId { get; set; }

        public int BookingId { get; set; }

        public string PassengerId { get; set; }

        public string TrainName { get; set; }
        public decimal Rate { get; set; }

        public string FeedBack { get; set; }

        public string GivenDate { get; set; }
    }
}
