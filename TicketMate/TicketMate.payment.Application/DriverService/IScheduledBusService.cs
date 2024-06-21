using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Payment.Application.DriverService
{
    public interface IScheduledBusService
    {
        Task<IEnumerable<object>> GetScheduledBusDetailsAsync(int isCompleted, int Id);
    }
}
