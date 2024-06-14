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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduledLocomotive>>> GetScheduledLocomotives()
        {
            return await _scheduledLocomotiveService.GetScheduledLocomotives();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduledLocomotive>> GetScheduledLocomotive(int id)
        {
            return await _scheduledLocomotiveService.GetScheduledLocomotive(id);
        }

        [HttpGet("by-train-schedule/{scheduledTrainSchedulId}")]
        public async Task<ActionResult<IEnumerable<ScheduledLocomotive>>> GetScheduledLocomotivesByTrainSchedulId(int scheduledTrainSchedulId)
        {
            return await _scheduledLocomotiveService.GetScheduledLocomotivesByTrainSchedulId(scheduledTrainSchedulId);
        }

        [HttpPost]
        public async Task<ActionResult<ScheduledLocomotive>> PostScheduledLocomotive(ScheduledLocomotive scheduledLocomotive)
        {
            return await _scheduledLocomotiveService.PostScheduledLocomotive(scheduledLocomotive);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutScheduledLocomotive(int id, ScheduledLocomotive scheduledLocomotive)
        {
            return await _scheduledLocomotiveService.PutScheduledLocomotive(id, scheduledLocomotive);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteScheduledLocomotive(int id)
        {
            return await _scheduledLocomotiveService.DeleteScheduledLocomotive(id);
        }
    }
}
