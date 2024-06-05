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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusRouteStand>>> GetBusRouteStands()
        {
            return await _busRouteStandService.GetBusRouteStands();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BusRouteStand>> GetBusRouteStand(int id)
        {
            return await _busRouteStandService.GetBusRouteStand(id);
        }

        [HttpGet("byroute/{routeId}")]
        public async Task<ActionResult<IEnumerable<BusRouteStand>>> GetBusRouteStandsByRouteId(int routeId)
        {
            return await _busRouteStandService.GetBusRouteStandsByRouteId(routeId);
        }

        [HttpPost]
        public async Task<ActionResult<BusRouteStand>> PostBusRouteStand(BusRouteStand busRouteStand)
        {
            return await _busRouteStandService.PostBusRouteStand(busRouteStand);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutBusRouteStand(int id, BusRouteStand busRouteStand)
        {
            return await _busRouteStandService.PutBusRouteStand(id, busRouteStand);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBusRouteStand(int id)
        {
            return await _busRouteStandService.DeleteBusRouteStand(id);
        }

        [HttpDelete("byroute/{routeId}")]
        public async Task<ActionResult> DeleteBusRouteStandsByRouteId(int routeId)
        {
            return await _busRouteStandService.DeleteBusRouteStandsByRouteId(routeId);
        }
    }
}
