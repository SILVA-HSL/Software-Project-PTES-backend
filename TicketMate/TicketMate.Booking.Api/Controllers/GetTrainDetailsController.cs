using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetTrainDetailsController : ControllerBase
    {
        private IBookingService _TrainDetails;

        public GetTrainDetailsController(IBookingService TrainDetails)
        {
            _TrainDetails = TrainDetails;
        }

        [HttpGet("{SchedulId}")]

        public IActionResult GetTrainDetailsWithSeats(int SchedulId)
        {
            var trainDetails = _TrainDetails.GetTrainDetailsWithSeats(SchedulId);
            return Ok(trainDetails);
        }
    }
}
