using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Payment.Data;

namespace TicketMate.Payment.Application.DriverService
{
    public class NotoifiBusScheduledIdService: INotoifiBusScheduledIdService
    {
        private readonly userDataDBContext _context;

        public NotoifiBusScheduledIdService(userDataDBContext context)
        {
            _context = context;
        }

        public async Task<List<int>> GetBusScheduleIdsByPassengerId(string passengerId)
        {
            var bookings = await _context.BusBookings
                .Where(b => b.PassengerId == passengerId)
                .Select(b => b.BusScheduleId)
                  .Distinct()
                .ToListAsync();

            return bookings;
        }
    }
}
