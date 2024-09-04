using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Payment.Application.DriverService
{
    public interface INotifiTrainScheduledIdService
    {
        Task<List<int>> GetTrainScheduleIdsByPassengerId(string passengerId);
    }
}
