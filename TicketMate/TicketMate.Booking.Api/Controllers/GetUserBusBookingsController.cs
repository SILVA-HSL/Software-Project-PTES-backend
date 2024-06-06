using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserBusBookingsController : ControllerBase
    {
        private IBookingService _UserBusBookings;

        public GetUserBusBookingsController(IBookingService UserBusBookings)
        {
            _UserBusBookings = UserBusBookings;
        }

        [HttpGet("{passengerId}")]

        public IActionResult GetUserBusBookings(string passengerId)
        {
            var userBusBookings = _UserBusBookings.GetUserBusBookings(passengerId);
            return Ok(userBusBookings);
        }
    }
}
