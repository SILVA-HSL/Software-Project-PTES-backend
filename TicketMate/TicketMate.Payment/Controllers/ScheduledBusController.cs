using Microsoft.AspNetCore.Mvc;
using TicketMate.Payment.Application.DriverService;

namespace TicketMate.Payment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduledBusController : ControllerBase
    {
        private readonly IScheduledBusService _scheduledBusService;

        public ScheduledBusController(IScheduledBusService scheduledBusService)
        {
            _scheduledBusService = scheduledBusService;
        }

        [HttpGet("details")]
        public async Task<ActionResult<IEnumerable<object>>> GetScheduledBusDetails([FromQuery] bool isCompleted,int Id)
        {
            var result = await _scheduledBusService.GetScheduledBusDetailsAsync(isCompleted,Id);
            return Ok(result);
        }


        [HttpPut("endbustrip/{id}")]
        public IActionResult endbustrip(int id)
        {
            _scheduledBusService.endbustrip(id);
            return Ok();
        }
    }
}
