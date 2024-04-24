/*using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;
using TicketMate.Booking.Infrastructure;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StartLocationController : ControllerBase
    {
        private IBookingService _travelSearchStart;

        public StartLocationController(IBookingService travelSearchStart)
        {
            _travelSearchStart = travelSearchStart;
        }

        [HttpGet]
        public IActionResult getStartLocation()
        {
            var StartLocations = _travelSearchStart.getAllStartLocations();
            return Ok(StartLocations);
        }

    }
}*/
