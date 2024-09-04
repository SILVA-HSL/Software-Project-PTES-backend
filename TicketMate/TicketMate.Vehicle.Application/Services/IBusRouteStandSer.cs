using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.Application.Services
{
    public interface IBusRouteStandSer
    {
        Task<ActionResult<IEnumerable<BusRouteStand>>> GetBusRouteStands();
        Task<ActionResult<BusRouteStand>> GetBusRouteStand(int id);
        Task<ActionResult<IEnumerable<BusRouteStand>>> GetBusRouteStandsByRouteId(int routeId);
        Task<ActionResult<BusRouteStand>> PostBusRouteStand(BusRouteStand busRouteStand);
        Task<ActionResult> PutBusRouteStand(int id, BusRouteStand busRouteStand);
        Task<ActionResult> DeleteBusRouteStand(int id);
        Task<ActionResult> DeleteBusRouteStandsByRouteId(int routeId);
    }
}
