using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Payment.Data;

namespace TicketMate.Payment.Application.DriverService
{
    public class NotifiTrainScheduledIdService : INotifiTrainScheduledIdService
    {
        private readonly userDataDBContext _context;

        public NotifiTrainScheduledIdService(userDataDBContext context)
        {
            _context = context;
        }

        public async Task<List<int>> GetTrainScheduleIdsByPassengerId(string passengerId)
        {
            var bookings = await _context.TrainBookings
                .Where(b => b.PassengerId == passengerId)
                .Select(b => b.TrainScheduleId)
                  .Distinct()
                .ToListAsync();

            return bookings;
        }
    }
}
