using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Vehicle.Application.Services;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduledTrainController : ControllerBase
    {
        private readonly IScheduledTrainSer _scheduledTrainService;

        public ScheduledTrainController(IScheduledTrainSer scheduledTrainService)
        {
            _scheduledTrainService = scheduledTrainService;
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduledTrain>>> GetScheduledTrains()
        {
            return await _scheduledTrainService.GetScheduledTrains();
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduledTrain>> GetScheduledTrain(int id)
        {
            return await _scheduledTrainService.GetScheduledTrain(id);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<ScheduledTrain>>> GetScheduledTrainsByUserId(string userId)
        {
            return await _scheduledTrainService.GetScheduledTrainsByUserId(userId);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpPost]
        public async Task<ActionResult<ScheduledTrain>> PostScheduledTrain(ScheduledTrain scheduledTrain)
        {
            return await _scheduledTrainService.PostScheduledTrain(scheduledTrain);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutScheduledTrain(int id, ScheduledTrain scheduledTrain)
        {
            return await _scheduledTrainService.PutScheduledTrain(id, scheduledTrain);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteScheduledTrain(int id)
        {
            return await _scheduledTrainService.DeleteScheduledTrain(id);
        }
    }
}
