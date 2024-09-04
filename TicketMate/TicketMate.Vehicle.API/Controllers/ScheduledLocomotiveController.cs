using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Vehicle.Application.Services;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduledLocomotiveController : ControllerBase
    {
        private readonly IScheduledLocomotiveSer _scheduledLocomotiveService;

        public ScheduledLocomotiveController(IScheduledLocomotiveSer scheduledLocomotiveService)
        {
            _scheduledLocomotiveService = scheduledLocomotiveService;
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduledLocomotive>>> GetScheduledLocomotives()
        {
            return await _scheduledLocomotiveService.GetScheduledLocomotives();
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduledLocomotive>> GetScheduledLocomotive(int id)
        {
            return await _scheduledLocomotiveService.GetScheduledLocomotive(id);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet("by-train-schedule/{scheduledTrainSchedulId}")]
        public async Task<ActionResult<IEnumerable<ScheduledLocomotive>>> GetScheduledLocomotivesByTrainSchedulId(int scheduledTrainSchedulId)
        {
            return await _scheduledLocomotiveService.GetScheduledLocomotivesByTrainSchedulId(scheduledTrainSchedulId);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpPost]
        public async Task<ActionResult<ScheduledLocomotive>> PostScheduledLocomotive(ScheduledLocomotive scheduledLocomotive)
        {
            return await _scheduledLocomotiveService.PostScheduledLocomotive(scheduledLocomotive);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutScheduledLocomotive(int id, ScheduledLocomotive scheduledLocomotive)
        {
            return await _scheduledLocomotiveService.PutScheduledLocomotive(id, scheduledLocomotive);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteScheduledLocomotive(int id)
        {
            return await _scheduledLocomotiveService.DeleteScheduledLocomotive(id);
        }
    }
}
