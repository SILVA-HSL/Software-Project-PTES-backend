using Microsoft.AspNetCore.Mvc;
using TicketMate.Payment.Application.DriverService;

namespace TicketMate.Payment.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TrainScheduledId : Controller
    {
        private readonly INotifiTrainScheduledIdService _trainBookingService;

        public TrainScheduledId(INotifiTrainScheduledIdService trainBookingService)
        {
            _trainBookingService = trainBookingService;
        }

        [HttpGet("GetBusScheduleIdsByPassengerId/{passengerId}")]
        public async Task<IActionResult> GetTrainScheduleIdsByPassengerId(string passengerId)
        {
            var trainScheduleIds = await _trainBookingService.GetTrainScheduleIdsByPassengerId(passengerId);

            if (trainScheduleIds == null || trainScheduleIds.Count == 0)
            {
                return NotFound();
            }

            return Ok(trainScheduleIds);
        }
    }
}
