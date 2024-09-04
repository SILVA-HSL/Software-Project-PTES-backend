using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Vehicle.Application.Services;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduledCarriageController : ControllerBase
    {
        private readonly IScheduledCarriageSer _scheduledCarriageService;

        public ScheduledCarriageController(IScheduledCarriageSer scheduledCarriageService)
        {
            _scheduledCarriageService = scheduledCarriageService;
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduledCarriage>>> GetScheduledCarriages()
        {
            return await _scheduledCarriageService.GetScheduledCarriages();
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduledCarriage>> GetScheduledCarriage(int id)
        {
            return await _scheduledCarriageService.GetScheduledCarriage(id);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpPost]
        public async Task<ActionResult<ScheduledCarriage>> PostScheduledCarriage(ScheduledCarriage scheduledCarriage)
        {
            return await _scheduledCarriageService.PostScheduledCarriage(scheduledCarriage);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutScheduledCarriage(int id, ScheduledCarriage scheduledCarriage)
        {
            return await _scheduledCarriageService.PutScheduledCarriage(id, scheduledCarriage);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteScheduledCarriage(int id)
        {
            return await _scheduledCarriageService.DeleteScheduledCarriage(id);
        }

        // New endpoint to get scheduled carriages by ScheduledTrainSchedulId
        [Authorize(Roles = "Admin,Owner")]
        [HttpGet("ByTrainSchedule/{scheduledTrainSchedulId}")]
        public async Task<ActionResult<IEnumerable<ScheduledCarriage>>> GetScheduledCarriagesByTrainScheduleId(int scheduledTrainSchedulId)
        {
            return await _scheduledCarriageService.GetScheduledCarriagesByTrainScheduleId(scheduledTrainSchedulId);
        }
    }
}
