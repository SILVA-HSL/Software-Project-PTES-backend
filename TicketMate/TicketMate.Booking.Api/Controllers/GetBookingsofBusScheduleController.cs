using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetBookingsofBusScheduleController : ControllerBase
    {
        private IBookingService _BookingsofBusSchedule;

        public GetBookingsofBusScheduleController(IBookingService BookingsofBusSchedule)
        {
            _BookingsofBusSchedule = BookingsofBusSchedule;
        }

        [HttpGet("{scheduleId}")]

        public IActionResult GetBookingsOfBusSchedule(int scheduleId, string selectedDate)
        {
            var bookingsOfSchedule = _BookingsofBusSchedule.GetBookingsOfBusSchedule(scheduleId, selectedDate);
            return Ok(bookingsOfSchedule);
        }
    }
}
