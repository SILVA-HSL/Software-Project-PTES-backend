using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Payment.Data;

namespace TicketMate.Payment.Application.DriverService
{
    public class ScheduledTrainService: IScheduledTrainService
    { 
    private readonly userDataDBContext _context;

    public ScheduledTrainService(userDataDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> GetScheduledTrainDetailsAsync(bool isCompleted, string Id)
    {
            var result = await   (from std in _context.ScheduledTrainDates
                          join st in _context.ScheduledTrains on std.ScheduledTrainSchedulId equals st.SchedulId
                          where st.UserId == Id && std.IsCompleted == isCompleted
                          select new
                          {
                              std.Id,
                              std.ArrivalDate,
                              st.TrainRoutNo,
                              st.StartStation,            
                              st.EndStation,
                              st.TrainDepartureTime,
                              st.TrainArrivalTime
                          }).ToListAsync();

            return result;
    }
    }
}
