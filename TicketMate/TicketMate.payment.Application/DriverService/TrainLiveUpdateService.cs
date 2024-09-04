using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Payment.Data;

namespace TicketMate.Payment.Application.DriverService
{
    public class TrainLiveUpdateService: ITrainLiveUpdateService
    {
        private readonly userDataDBContext _context;

        public TrainLiveUpdateService(userDataDBContext context)
        {
            _context = context;
        }

        public async Task<List<int>> GetPassengerIdsForScheduledTrainAsync(int scheduledId)
        {
            return await _context.TrainBookings
                .Where(train => train.TrainScheduleId == scheduledId)
                .Select(train => Convert.ToInt32(train.PassengerId))
                .Distinct()
                .ToListAsync();
        }
    }
}
