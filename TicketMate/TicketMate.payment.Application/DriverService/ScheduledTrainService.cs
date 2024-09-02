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

    public async Task<IEnumerable<object>> GetScheduledTrainDetailsAsync(bool isCompleted, int Id)
    {
            var result = await   (from std in _context.ScheduledTrainDates
                          join st in _context.ScheduledTrains on std.ScheduledTrainSchedulId equals st.SchedulId
                          where st.TrainDriverId == Id && std.IsCompleted == isCompleted
                          select new
                          {
                              std.Id,
                              std.ArrivalDate,
                              st.TrainRoutNo,
                              st.StartStation,            
                              st.EndStation,
                              st.TrainDepartureTime,
                              st.TrainArrivalTime,
                              st.TrainName,
                              
                          }).ToListAsync();

            return result;
    }
        public void endtraintrip(int id)
        {
            var scheduledTrainDates = _context.ScheduledTrainDates.Find(id);
            if (scheduledTrainDates != null)
            {
                scheduledTrainDates.IsCompleted = true;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Scheduled Bus Date Not Found");
            }
        }





    }
}
