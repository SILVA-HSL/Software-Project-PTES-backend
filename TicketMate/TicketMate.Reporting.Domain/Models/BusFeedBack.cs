using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Reporting.Domain.Models
{
    public class BusFeedBack
    {
        [Key]
        public int FeedBackId { get; set; }

        public int BusId { get; set; }

        public int BookingId { get; set; }

        public string PassengerId { get; set; }

        public decimal Rate { get; set; }

        public string FeedBack { get; set; }

        public string GivenDate { get; set; }


    }
}
