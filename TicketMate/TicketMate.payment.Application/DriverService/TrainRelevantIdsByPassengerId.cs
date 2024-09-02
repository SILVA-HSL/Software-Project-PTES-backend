using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Payment.Data;

namespace TicketMate.Payment.Application.DriverService
{
    public class TrainRelevantIdsByPassengerId : ITrainRelevantIdsByPassengerId
    {
        private readonly userDataDBContext _context;

        public TrainRelevantIdsByPassengerId(userDataDBContext context)
        {
            _context = context;
        }

        public async Task<List<int>> GetRelevantIdsByPassengerIdAsync(string passengerId)
        {
            // Filter TrainBookings based on PassengerId
            var trainBookings = await _context.TrainBookings
                .Where(b => b.PassengerId == passengerId)
                .Select(b => new { b.TrainScheduleId, b.BookingDate })
                .ToListAsync();

            var scheduleIds = trainBookings.Select(b => b.TrainScheduleId).Distinct();
            var bookingDates = trainBookings.Select(b => b.BookingDate).Distinct();

            // Filter ScheduledTrainDates based on TrainScheduleId and BookingDate
            var relevantIds = await _context.ScheduledTrainDates
                .Where(s => scheduleIds.Contains(s.ScheduledTrainSchedulId) && bookingDates.Contains(s.DepartureDate))
                .Select(s => s.Id)
                .ToListAsync();

            return relevantIds;
        }
    }
}
