using Microsoft.AspNetCore.Mvc;
using TicketMate.Payment.Application.DriverService;

namespace TicketMate.Payment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduledtrainController : ControllerBase
    {
        private readonly IScheduledTrainService _scheduledTrainService;

        public ScheduledtrainController(IScheduledTrainService scheduledTrainService)
        {
            _scheduledTrainService = scheduledTrainService;
        }


        [HttpGet("details")]
        public async Task<ActionResult<IEnumerable<object>>> GetScheduledTrainDetails([FromQuery] bool isCompleted, string Id)
        {
            var result = await _scheduledTrainService.GetScheduledTrainDetailsAsync(isCompleted, Id);
            return Ok(result);
        }
    }
}
