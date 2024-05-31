using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetBookingsOfTrainScheduleController : ControllerBase
    {
        private IBookingService _BookingsofTrainSchedule;

        public GetBookingsOfTrainScheduleController(IBookingService BookingsofTrainSchedule)
        {
            _BookingsofTrainSchedule = BookingsofTrainSchedule;
        }

        [HttpGet("{scheduleId}")]

        public IActionResult GetBookingsOfBusSchedule(int scheduleId, string selectedDate)
        {
            var bookingsOfSchedule = _BookingsofTrainSchedule.GetBookingsOfTrainSchedule(scheduleId, selectedDate);
            return Ok(bookingsOfSchedule);
        }
    }
}
