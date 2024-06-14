using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Vehicle.Application.Services;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchBusStandController : ControllerBase
    {
        private readonly ISchBusStandSer _schBusStandService;

        public SchBusStandController(ISchBusStandSer schBusStandService)
        {
            _schBusStandService = schBusStandService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelectedBusStand>>> GetSelectedBusStands()
        {
            return await _schBusStandService.GetSelectedBusStands();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SelectedBusStand>> GetSelectedBusStand(int id)
        {
            return await _schBusStandService.GetSelectedBusStand(id);
        }

        [HttpPost]
        public async Task<ActionResult<SelectedBusStand>> PostSelectedBusStand(SelectedBusStand selectedBusStand)
        {
            return await _schBusStandService.PostSelectedBusStand(selectedBusStand);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSelectedBusStand(int id, SelectedBusStand selectedBusStand)
        {
            return await _schBusStandService.PutSelectedBusStand(id, selectedBusStand);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSelectedBusStand(int id)
        {
            return await _schBusStandService.DeleteSelectedBusStand(id);
        }

        [HttpGet("schedule/{scheduleId}")]
        public async Task<ActionResult<IEnumerable<SelectedBusStand>>> GetSelectedBusStandsByScheduleId(int scheduleId)
        {
            return await _schBusStandService.GetSelectedBusStandsByScheduleId(scheduleId);
        }

        [HttpPut("schedule/{scheduleId}")]
        public async Task<ActionResult> PutSelectedBusStandByScheduleId(int scheduleId, SelectedBusStand selectedBusStand)
        {
            return await _schBusStandService.PutSelectedBusStandByScheduleId(scheduleId, selectedBusStand);
        }

        [HttpDelete("schedule/{scheduleId}")]
        public async Task<ActionResult> DeleteSelectedBusStandsByScheduleId(int scheduleId)
        {
            return await _schBusStandService.DeleteSelectedBusStandsByScheduleId(scheduleId);
        }
    }
}
