using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserTrainBookingsController : ControllerBase
    {
        private IBookingService _UserTrainBookings;

        public GetUserTrainBookingsController(IBookingService UserTrainBookings)
        {
            _UserTrainBookings = UserTrainBookings;
        }

        [HttpGet("{passengerId}")]

        public IActionResult GetUserTrainBookings(string passengerId)
        {
            var userTrainBookings = _UserTrainBookings.GetUserTrainBookings(passengerId);
            return Ok(userTrainBookings);
        }   
    }
}
