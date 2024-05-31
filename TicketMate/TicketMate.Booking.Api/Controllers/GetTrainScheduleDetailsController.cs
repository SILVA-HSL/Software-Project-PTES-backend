using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetTrainScheduleDetailsController : ControllerBase
    {
        private IBookingService _trainScheduleDetails;

        public GetTrainScheduleDetailsController(IBookingService trainScheduleDetails)
        {
            _trainScheduleDetails = trainScheduleDetails;
        }

        [HttpGet("{scheduleId}")]
        public IActionResult GetTrainScheduleDetails(int scheduleId)
        {
            var scheduleDetails = _trainScheduleDetails.GetTrainScheduleDetails(scheduleId);
            if (scheduleDetails == null)
            {
                return NotFound();
            }
            return Ok(scheduleDetails);
        }
    }
}
