using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetBusDetailsController : ControllerBase
    {
        private IBookingService _BusDetails;

        public GetBusDetailsController(IBookingService BusDetails)
        {
            _BusDetails = BusDetails;
        }

        [HttpGet("{registeredBusBusId}")]

        public IActionResult GetBusDetailsWithSeats(int registeredBusBusId)
        {
            var busDetails = _BusDetails.GetBusDetailsWithSeats(registeredBusBusId);
            return Ok(busDetails);
        }



    }
}
