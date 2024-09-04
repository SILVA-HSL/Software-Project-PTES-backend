using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Vehicle.API.Models;
using TicketMate.Vehicle.Infastructure;

namespace TicketMate.Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusRegController : ControllerBase
    {
        private readonly IRegBusSer _regBusService;

        public BusRegController(IRegBusSer regBusService)
        {
            _regBusService = regBusService;
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisteredBus>>> GetRegBuses()
        {
            return await _regBusService.GetRegBuses();
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisteredBus>> GetRegBus(int id)
        {
            return await _regBusService.GetRegBus(id);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet("byUser/{userId}")]
        public async Task<ActionResult<IEnumerable<RegisteredBus>>> GetRegBusesByUserId(string userId)
        {
            return await _regBusService.GetRegBusesByUserId(userId);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpPost]
        public async Task<ActionResult<RegisteredBus>> PostRegBuses(RegisteredBus busRegistration)
        {
            return await _regBusService.PostRegBuses(busRegistration);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutRegBuses(int id, RegisteredBus busRegistration)
        {
            return await _regBusService.PutRegBuses(id, busRegistration);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRegBus(int id)
        {
            return await _regBusService.DeleteRegBus(id);
        }
    }
}
