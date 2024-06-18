using Microsoft.AspNetCore.Mvc;
using TicketMate.Vehicle.Application.Services;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduledTrainDateController : ControllerBase
    {
        private readonly IScheduledTrainDateSer _scheduledTrainDateService;

        public ScheduledTrainDateController(IScheduledTrainDateSer scheduledTrainDateService)
        {
            _scheduledTrainDateService = scheduledTrainDateService;
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduledTrainDate>>> GetScheduledTrainDates()
        {
            return await _scheduledTrainDateService.GetScheduledTrainDates();
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduledTrainDate>> GetScheduledTrainDate(int id)
        {
            return await _scheduledTrainDateService.GetScheduledTrainDate(id);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpGet("ByScheduledTrainSchedulId/{scheduledTrainSchedulId}")]
        public async Task<ActionResult<IEnumerable<ScheduledTrainDate>>> GetScheduledTrainDatesByScheduledTrainSchedulId(int scheduledTrainSchedulId)
        {
            return await _scheduledTrainDateService.GetScheduledTrainDatesByScheduledTrainSchedulId(scheduledTrainSchedulId);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpPost]
        public async Task<ActionResult<ScheduledTrainDate>> PostScheduledTrainDate(ScheduledTrainDate scheduledTrainDate)
        {
            return await _scheduledTrainDateService.PostScheduledTrainDate(scheduledTrainDate);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutScheduledTrainDate(int id, ScheduledTrainDate scheduledTrainDate)
        {
            return await _scheduledTrainDateService.PutScheduledTrainDate(id, scheduledTrainDate);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteScheduledTrainDate(int id)
        {
            return await _scheduledTrainDateService.DeleteScheduledTrainDate(id);
        }
    }
}
