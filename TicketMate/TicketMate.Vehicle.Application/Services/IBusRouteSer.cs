using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.Application.Services
{
    public interface IBusRouteSer
    {
        Task<ActionResult<IEnumerable<BusRoute>>> GetBusRoutes();
        Task<ActionResult<BusRoute>> GetBusRoute(int id);
        Task<ActionResult<BusRoute>> GetBusRouteByRoutNo(string routNo); // New method
        Task<ActionResult<BusRoute>> PostBusRoute(BusRoute busRoute);
        Task<ActionResult> PutBusRoute(int id, BusRoute busRoute);
        Task<ActionResult> DeleteBusRoute(int id);
        Task<ActionResult> DeleteBusRouteByRoutNo(string routNo); // New method
    }
}
