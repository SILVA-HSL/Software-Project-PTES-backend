using Microsoft.AspNetCore.Mvc;
using TicketMate.Vehicle.Application.Services;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainRaliwayController : ControllerBase
    {
        private readonly ITrainRaliwaySer _trainRaliwayService;

        public TrainRaliwayController(ITrainRaliwaySer trainRaliwayService)
        {
            _trainRaliwayService = trainRaliwayService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainRaliway>>> GetTrainRaliways()
        {
            return await _trainRaliwayService.GetTrainRaliways();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainRaliway>> GetTrainRaliway(int id)
        {
            return await _trainRaliwayService.GetTrainRaliway(id);
        }

        [HttpGet("byRailwayNo/{railwayNo}")]
        public async Task<ActionResult<TrainRaliway>> GetTrainRaliwayByNo(int railwayNo)
        {
            return await _trainRaliwayService.GetTrainRaliwayByNo(railwayNo);
        }

        [HttpPost]
        public async Task<ActionResult<TrainRaliway>> PostTrainRaliway(TrainRaliway trainRaliway)
        {
            return await _trainRaliwayService.PostTrainRaliway(trainRaliway);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTrainRaliway(int id, TrainRaliway trainRaliway)
        {
            return await _trainRaliwayService.PutTrainRaliway(id, trainRaliway);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTrainRaliway(int id)
        {
            return await _trainRaliwayService.DeleteTrainRaliway(id);
        }
    }
}
