using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Payment.Data;
using TicketMate.Payment.Domain.Model;

namespace TicketMate.Payment.Application.BookingServices
{
    public class TrainBookingService: ITrainBookingService
    {
        private readonly userDataDBContext _context;
        public TrainBookingService(userDataDBContext context)
        {
            _context = context;
        }

        public async Task<TrainBookings> CreateBookingAsync(TrainBookings booking)
        {
            _context.TrainBookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
    }   
   
}
    
