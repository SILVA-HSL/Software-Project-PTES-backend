using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainRaliwayStation>>> GetTrainRaliwayStations()
        {
            return await _trainRaliwayStationService.GetTrainRaliwayStations();
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainRaliwayStation>> GetTrainRaliwayStation(int id)
        {
            return await _trainRaliwayStationService.GetTrainRaliwayStation(id);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet("byTrainRaliwayId/{trainRaliwayId}")]
        public async Task<ActionResult<IEnumerable<TrainRaliwayStation>>> GetTrainRaliwayStationsByRaliwayId(int trainRaliwayId)
        {
            return await _trainRaliwayStationService.GetTrainRaliwayStationsByRaliwayId(trainRaliwayId);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpPost]
        public async Task<ActionResult<TrainRaliwayStation>> PostTrainRaliwayStation(TrainRaliwayStation trainRaliwayStation)
        {
            return await _trainRaliwayStationService.PostTrainRaliwayStation(trainRaliwayStation);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutTrainRaliwayStation(int id, TrainRaliwayStation trainRaliwayStation)
        {
            return await _trainRaliwayStationService.PutTrainRaliwayStation(id, trainRaliwayStation);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTrainRaliwayStation(int id)
        {
            return await _trainRaliwayStationService.DeleteTrainRaliwayStation(id);
        }
    }
}
