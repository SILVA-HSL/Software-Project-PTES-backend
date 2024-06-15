using Microsoft.AspNetCore.Mvc;
using TicketMate.Vehicle.Application.Services;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduledBusDateController : ControllerBase
    {
        private readonly IScheduledBusDateSer _scheduledBusDateService;

        public ScheduledBusDateController(IScheduledBusDateSer scheduledBusDateService)
        {
            _scheduledBusDateService = scheduledBusDateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduledBusDate>>> GetScheduledBusDates()
        {
            return await _scheduledBusDateService.GetScheduledBusDates();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduledBusDate>> GetScheduledBusDate(int id)
        {
            return await _scheduledBusDateService.GetScheduledBusDate(id);
        }

        [HttpGet("ByScheduleId/{scheduleId}")]
        public async Task<ActionResult<IEnumerable<ScheduledBusDate>>> GetScheduledBusDatesByScheduleId(int scheduleId)
        {
            return await _scheduledBusDateService.GetScheduledBusDatesByScheduleId(scheduleId);
        }

        [HttpPost]
        public async Task<ActionResult<ScheduledBusDate>> PostScheduledBusDate(ScheduledBusDate scheduledBusDate)
        {
            return await _scheduledBusDateService.PostScheduledBusDate(scheduledBusDate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutScheduledBusDate(int id, ScheduledBusDate scheduledBusDate)
        {
            return await _scheduledBusDateService.PutScheduledBusDate(id, scheduledBusDate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteScheduledBusDate(int id)
        {
            return await _scheduledBusDateService.DeleteScheduledBusDate(id);
        }

        [HttpDelete("ByScheduleId/{scheduleId}")]
        public async Task<ActionResult> DeleteScheduledBusDatesByScheduleId(int scheduleId)
        {
            return await _scheduledBusDateService.DeleteScheduledBusDatesByScheduleId(scheduleId);
        }
    }
}
