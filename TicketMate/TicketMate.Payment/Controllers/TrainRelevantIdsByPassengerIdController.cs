using Microsoft.AspNetCore.Mvc;
using TicketMate.Payment.Application.BookingServices;
using TicketMate.Payment.Application.DriverService;

namespace TicketMate.Payment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainRelevantIdsByPassengerIdController : Controller
    {
        private readonly ITrainRelevantIdsByPassengerId _trainBookingService;

        public TrainRelevantIdsByPassengerIdController(ITrainRelevantIdsByPassengerId trainBookingService)
        {
            _trainBookingService = trainBookingService;
        }

        [HttpGet("relevant-ids/{passengerId}")]
        public async Task<IActionResult> GetRelevantIds(string passengerId)
        {
            if (string.IsNullOrEmpty(passengerId))
            {
                return BadRequest("PassengerId is required.");
            }

            var relevantIds = await _trainBookingService.GetRelevantIdsByPassengerIdAsync(passengerId);

            if (relevantIds == null || !relevantIds.Any())
            {
                return NotFound("No relevant IDs found for the given PassengerId.");
            }

            return Ok(relevantIds);
        }
    }
}
