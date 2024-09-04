using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Payment.Domain.Model;
using TicketMate.Payment.Data;

namespace TicketMate.Payment.Application.BookingServices
{
    public class BusBookingService: IBusBookingService
    {
        private readonly userDataDBContext _context;
        public BusBookingService(userDataDBContext context)
        {
            _context = context;
        }

        public async Task<BusBookings> CreateBookingAsync(BusBookings booking)
        {
            _context.BusBookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
    }
}
