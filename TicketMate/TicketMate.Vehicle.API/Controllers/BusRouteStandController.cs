using Microsoft.AspNetCore.Mvc;
using TicketMate.Vehicle.Application.Services;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusRouteStandController : ControllerBase
    {
        private readonly IBusRouteStandSer _busRouteStandService;

        public BusRouteStandController(IBusRouteStandSer busRouteStandService)
        {
            _busRouteStandService = busRouteStandService;
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusRouteStand>>> GetBusRouteStands()
        {
            return await _busRouteStandService.GetBusRouteStands();
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpGet("{id}")]
        public async Task<ActionResult<BusRouteStand>> GetBusRouteStand(int id)
        {
            return await _busRouteStandService.GetBusRouteStand(id);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpGet("byroute/{routeId}")]
        public async Task<ActionResult<IEnumerable<BusRouteStand>>> GetBusRouteStandsByRouteId(int routeId)
        {
            return await _busRouteStandService.GetBusRouteStandsByRouteId(routeId);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpPost]
        public async Task<ActionResult<BusRouteStand>> PostBusRouteStand(BusRouteStand busRouteStand)
        {
            return await _busRouteStandService.PostBusRouteStand(busRouteStand);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutBusRouteStand(int id, BusRouteStand busRouteStand)
        {
            return await _busRouteStandService.PutBusRouteStand(id, busRouteStand);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBusRouteStand(int id)
        {
            return await _busRouteStandService.DeleteBusRouteStand(id);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpDelete("byroute/{routeId}")]
        public async Task<ActionResult> DeleteBusRouteStandsByRouteId(int routeId)
        {
            return await _busRouteStandService.DeleteBusRouteStandsByRouteId(routeId);
        }
    }
}
