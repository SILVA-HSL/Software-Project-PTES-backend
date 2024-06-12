using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Payment.Domain.Model;

namespace TicketMate.Payment.Application.BookingServices
{
    public interface ITrainBookingService
    {
        Task<TrainBookings> CreateBookingAsync(TrainBookings booking);
    }
}
