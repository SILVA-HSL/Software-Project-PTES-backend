using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduledBusDate>>> GetScheduledBusDates()
        {
            return await _scheduledBusDateService.GetScheduledBusDates();
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduledBusDate>> GetScheduledBusDate(int id)
        {
            return await _scheduledBusDateService.GetScheduledBusDate(id);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet("ByScheduleId/{scheduleId}")]
        public async Task<ActionResult<IEnumerable<ScheduledBusDate>>> GetScheduledBusDatesByScheduleId(int scheduleId)
        {
            return await _scheduledBusDateService.GetScheduledBusDatesByScheduleId(scheduleId);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpPost]
        public async Task<ActionResult<ScheduledBusDate>> PostScheduledBusDate(ScheduledBusDate scheduledBusDate)
        {
            return await _scheduledBusDateService.PostScheduledBusDate(scheduledBusDate);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutScheduledBusDate(int id, ScheduledBusDate scheduledBusDate)
        {
            return await _scheduledBusDateService.PutScheduledBusDate(id, scheduledBusDate);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteScheduledBusDate(int id)
        {
            return await _scheduledBusDateService.DeleteScheduledBusDate(id);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpDelete("ByScheduleId/{scheduleId}")]
        public async Task<ActionResult> DeleteScheduledBusDatesByScheduleId(int scheduleId)
        {
            return await _scheduledBusDateService.DeleteScheduledBusDatesByScheduleId(scheduleId);
        }
    }
}
