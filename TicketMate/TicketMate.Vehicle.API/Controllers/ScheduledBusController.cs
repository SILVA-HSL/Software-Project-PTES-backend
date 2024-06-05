using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketMate.Vehicle.API.Models;
using TicketMate.Vehicle.Application.Services;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduledBusController : ControllerBase
    {
        private readonly IScheduledBusSer _scheduledBusService;

        public ScheduledBusController(IScheduledBusSer scheduledBusService)
        {
            _scheduledBusService = scheduledBusService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduledBus>>> GetScheduledBuses()
        {
            return await _scheduledBusService.GetScheduledBuses();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduledBus>> GetScheduledBus(int id)
        {
            return await _scheduledBusService.GetScheduledBus(id);
        }

        [HttpPost]
        public async Task<ActionResult<ScheduledBus>> PostScheduledBus(ScheduledBus scheduledBus)
        {
            return await _scheduledBusService.PostScheduledBus(scheduledBus);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutScheduledBus(int id, ScheduledBus scheduledBus)
        {
            return await _scheduledBusService.PutScheduledBus(id, scheduledBus);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteScheduledBus(int id)
        {
            return await _scheduledBusService.DeleteScheduledBus(id);
        }

        // New endpoint to get scheduled buses by UserId
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<ScheduledBus>>> GetScheduledBusesByUserId(string userId)
        {
            return await _scheduledBusService.GetScheduledBusesByUserId(userId);
        }
    }
}
