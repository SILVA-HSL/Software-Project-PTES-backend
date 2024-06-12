using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Payment.Domain.Model;

namespace TicketMate.Payment.Application.DriverService
{
    public interface IDriverBreakdownService
    {
        Task<DriverBreakdown> CreateDriverBreakdownAsync(int driverId);
    }
}
