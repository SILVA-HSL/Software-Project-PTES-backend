using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;
//using TicketMate.Booking.Infrastructure;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndLocationController : ControllerBase
    {

        private readonly IBookingService _travelSearchEnd;

        public EndLocationController(IBookingService travelSearchEnd)
        {
            _travelSearchEnd = travelSearchEnd;
        }

        [HttpGet]
        public IActionResult getEndLocation()
        {
            var EndLocations = _travelSearchEnd.getAllEndLocations();
            return Ok(EndLocations);
        }


    }
}
