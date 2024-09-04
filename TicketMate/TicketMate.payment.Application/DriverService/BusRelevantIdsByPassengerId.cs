using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Payment.Data;

namespace TicketMate.Payment.Application.DriverService
{
    public class BusRelevantIdsByPassengerId: IBusRelevantIdsByPassengerId
    {
        private readonly userDataDBContext _context;

        public BusRelevantIdsByPassengerId(userDataDBContext context)
        {
            _context = context;
        }

        public async Task<List<int>> GetRelevantIdsByPassengerIdAsync(string passengerId)
        {
            // Filter BusBookings based on PassengerId
            var busBookings = _context.BusBookings
                .Where(b => b.PassengerId == passengerId)
                .Select(b => new { b.BusScheduleId, b.BookingDate })
                .ToList();

            var scheduleIds = busBookings.Select(b => b.BusScheduleId).Distinct();
            var bookingDates = busBookings.Select(b => b.BookingDate).Distinct();

            // Filter ScheduledBusDates based on BusScheduleId and BookingDate
            var relevantIds = _context.ScheduledBusDates
                .Where(s => scheduleIds.Contains(s.ScheduledBusScheduleId) && bookingDates.Contains(s.DepartureDate))
                .Select(s => s.Id)
                .ToList();

            return relevantIds;
        }
    }
}