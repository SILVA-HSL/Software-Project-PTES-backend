using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Payment.Data;

namespace TicketMate.Payment.Application.DriverService
{
    public class BusLiveUpdateService : IBusLiveUpdateService
    {
        private readonly userDataDBContext _context;

        public BusLiveUpdateService(userDataDBContext context)
        {
            _context = context;
        }

        public async Task<List<int>> GetPassengerIdsForScheduledBusAsync(int scheduledId)
        {
            return await _context.BusBookings
                .Where(bus => bus.BusScheduleId == scheduledId)
                .Select(bus => Convert.ToInt32(bus.PassengerId))
                .Distinct()
                .ToListAsync();
        }
    }
}
