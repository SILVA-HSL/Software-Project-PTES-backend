using Microsoft.AspNetCore.Mvc;
using TicketMate.Vehicle.Application.Services;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectedTrainStationController : ControllerBase
    {
        private readonly ISelectedTrainStationSer _selectedTrainStationService;

        public SelectedTrainStationController(ISelectedTrainStationSer selectedTrainStationService)
        {
            _selectedTrainStationService = selectedTrainStationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelectedTrainStation>>> GetSelectedTrainStations()
        {
            return await _selectedTrainStationService.GetSelectedTrainStations();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SelectedTrainStation>> GetSelectedTrainStation(int id)
        {
            return await _selectedTrainStationService.GetSelectedTrainStation(id);
        }

        [HttpGet("scheduledTrain/{scheduledTrainSchedulId}")]
        public async Task<ActionResult<IEnumerable<SelectedTrainStation>>> GetSelectedTrainStationsByScheduledTrainSchedulId(int scheduledTrainSchedulId)
        {
            return await _selectedTrainStationService.GetSelectedTrainStationsByScheduledTrainSchedulId(scheduledTrainSchedulId);
        }

        [HttpPost]
        public async Task<ActionResult<SelectedTrainStation>> PostSelectedTrainStation(SelectedTrainStation selectedTrainStation)
        {
            return await _selectedTrainStationService.PostSelectedTrainStation(selectedTrainStation);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSelectedTrainStation(int id, SelectedTrainStation selectedTrainStation)
        {
            return await _selectedTrainStationService.PutSelectedTrainStation(id, selectedTrainStation);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSelectedTrainStation(int id)
        {
            return await _selectedTrainStationService.DeleteSelectedTrainStation(id);
        }
    }
}
