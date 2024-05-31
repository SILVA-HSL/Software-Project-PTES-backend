using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetBusScheduleDetailsController : ControllerBase
    {
        private IBookingService _scheduleDetails;

        public GetBusScheduleDetailsController(IBookingService scheduleDetails)
        {
            _scheduleDetails = scheduleDetails;
        }

        [HttpGet("{scheduleId}")]
        public IActionResult GetBusScheduleDetails(int scheduleId)
        {
            var scheduleDetails = _scheduleDetails.GetBusScheduleDetails(scheduleId);
            if (scheduleDetails == null)
            {
                return NotFound();
            }
            return Ok(scheduleDetails);
        }
    }
}
