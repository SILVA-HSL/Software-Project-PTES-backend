using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Payment.Domain.Model;
using TicketMate.Payment.Data;

namespace TicketMate.Payment.Application.DriverService
{
 
        public class DriverBreakdownService : IDriverBreakdownService
        {
            private readonly userDataDBContext _context;

            public DriverBreakdownService(userDataDBContext context)
            {
                _context = context;
            }

            public async Task<DriverBreakdown> CreateDriverBreakdownAsync(int driverId,string BusNo)
            {
                var breakdown = new DriverBreakdown
                {
                    DriverId = driverId,
                    BusNo = BusNo,
                    Date = DateTime.UtcNow,
                    BreakdownStatus = 1
                };

                _context.DriverBreakdowns.Add(breakdown);
                await _context.SaveChangesAsync();

                return breakdown;
            }
        }
    
}
