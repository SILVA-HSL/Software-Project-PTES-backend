using Microsoft.AspNetCore.Mvc;
using TicketMate.Payment.Application.DriverService;

namespace TicketMate.Payment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusRelevantIdsByPassengerIdController : Controller
    {
        private readonly IBusRelevantIdsByPassengerId _bookingService;

        public BusRelevantIdsByPassengerIdController(IBusRelevantIdsByPassengerId bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("relevant-ids/{passengerId}")]
        public async Task<IActionResult> GetRelevantIds(string passengerId)
        {
            if (string.IsNullOrEmpty(passengerId))
            {
                return BadRequest("PassengerId is required.");
            }

            var relevantIds = await _bookingService.GetRelevantIdsByPassengerIdAsync(passengerId);

            if (relevantIds == null || !relevantIds.Any())
            {
                return NotFound("No relevant IDs found for the given PassengerId.");
            }

            return Ok(relevantIds);
        }
    }
}
