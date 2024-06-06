using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Booking.Domain.Models
{
    public class CancelledTrainBooking
    {

        [Key]
        public int TrainBookingId { get; set; }
        public int TrainScheduleId { get; set; }
        public string PassengerId { get; set; }
        public string RouteNo { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public string BoardingPoint { get; set; }
        public string DroppingPoint { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string BookingDate { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string BookingClass { get; set; }
        public int BookingCarriageNo { get; set; }
        public string BookingSeatNO { get; set; }
        public string BookingSeatCount { get; set; }
        public decimal TicketPrice { get; set; }
        public decimal TotalPaymentAmount { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
