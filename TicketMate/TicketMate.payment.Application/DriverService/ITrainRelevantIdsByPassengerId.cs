using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Payment.Application.DriverService
{
    public interface ITrainRelevantIdsByPassengerId
    {
        Task<List<int>> GetRelevantIdsByPassengerIdAsync(string passengerId);
    }
}
