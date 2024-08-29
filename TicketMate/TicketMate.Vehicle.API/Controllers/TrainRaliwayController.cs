using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainRaliway>>> GetTrainRaliways()
        {
            return await _trainRaliwayService.GetTrainRaliways();
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainRaliway>> GetTrainRaliway(int id)
        {
            return await _trainRaliwayService.GetTrainRaliway(id);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet("byRailwayNo/{railwayNo}")]
        public async Task<ActionResult<TrainRaliway>> GetTrainRaliwayByNo(int railwayNo)
        {
            return await _trainRaliwayService.GetTrainRaliwayByNo(railwayNo);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpPost]
        public async Task<ActionResult<TrainRaliway>> PostTrainRaliway(TrainRaliway trainRaliway)
        {
            return await _trainRaliwayService.PostTrainRaliway(trainRaliway);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutTrainRaliway(int id, TrainRaliway trainRaliway)
        {
            return await _trainRaliwayService.PutTrainRaliway(id, trainRaliway);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTrainRaliway(int id)
        {
            return await _trainRaliwayService.DeleteTrainRaliway(id);
        }
    }
}
