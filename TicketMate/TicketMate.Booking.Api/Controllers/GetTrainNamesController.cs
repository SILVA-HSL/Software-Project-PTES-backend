using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetTrainNamesController : ControllerBase
    {
        private IBookingService _trainName;

        public GetTrainNamesController(IBookingService trainName)
        {
            _trainName = trainName;
        }

        [HttpGet]
        public IActionResult GetTrainName(int trainScheduleId)
        {
            var trainName = _trainName.GetTrainName(trainScheduleId);
            return Ok(trainName);
        }
    }
}
