
using Microsoft.EntityFrameworkCore;
using TicketMate.Payment.Data;
using TicketMate.Payment.Model;

namespace TicketMate.Payment.Application.DriverService
{
    public class ScheduledBusService : IScheduledBusService
    {
        private readonly userDataDBContext _context;

        public ScheduledBusService(userDataDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> GetScheduledBusDetailsAsync(int isCompleted,int Id)
        {
            var result = await (from sbd in _context.ScheduledBusDates
                                join sb in _context.ScheduledBuses on sbd.ScheduledBusScheduleId equals sb.ScheduleId
                                where sb.DriverId == Id && sbd.IsCompleted == isCompleted
                                select new
                                {
                                    sbd.Id,
                                    sbd.ArrivalDate,
                                    sb.RoutNo,
                                    sb.StartLocation,
                                    sb.EndLocation,
                                    sb.DepartureTime,
                                    sb.ArrivalTime,
                                    sb.BusNo,
                                    sb.RegisteredBusBusId
                                }).ToListAsync();

            return result;
        }
    }
}
           