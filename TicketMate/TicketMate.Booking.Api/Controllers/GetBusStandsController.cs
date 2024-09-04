using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetBusStandsController : ControllerBase
    {
        private IBookingService _busService;

        public GetBusStandsController(IBookingService busService)
        {
            _busService = busService;
        }

        [HttpGet]
        public IActionResult getAllBusStands()
        {
            var busStands = _busService.getAllBusStands();
            return Ok(busStands);
        }
    }
}
