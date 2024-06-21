using Microsoft.AspNetCore.Mvc;
using TicketMate.Vehicle.Application.Services;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainRaliwayStationController : ControllerBase
    {
        private readonly ITrainRaliwayStationSer _trainRaliwayStationService;

        public TrainRaliwayStationController(ITrainRaliwayStationSer trainRaliwayStationService)
        {
            _trainRaliwayStationService = trainRaliwayStationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainRaliwayStation>>> GetTrainRaliwayStations()
        {
            return await _trainRaliwayStationService.GetTrainRaliwayStations();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainRaliwayStation>> GetTrainRaliwayStation(int id)
        {
            return await _trainRaliwayStationService.GetTrainRaliwayStation(id);
        }

        [HttpGet("byTrainRaliwayId/{trainRaliwayId}")]
        public async Task<ActionResult<IEnumerable<TrainRaliwayStation>>> GetTrainRaliwayStationsByRaliwayId(int trainRaliwayId)
        {
            return await _trainRaliwayStationService.GetTrainRaliwayStationsByRaliwayId(trainRaliwayId);
        }

        [HttpPost]
        public async Task<ActionResult<TrainRaliwayStation>> PostTrainRaliwayStation(TrainRaliwayStation trainRaliwayStation)
        {
            return await _trainRaliwayStationService.PostTrainRaliwayStation(trainRaliwayStation);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTrainRaliwayStation(int id, TrainRaliwayStation trainRaliwayStation)
        {
            return await _trainRaliwayStationService.PutTrainRaliwayStation(id, trainRaliwayStation);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTrainRaliwayStation(int id)
        {
            return await _trainRaliwayStationService.DeleteTrainRaliwayStation(id);
        }
    }
}
