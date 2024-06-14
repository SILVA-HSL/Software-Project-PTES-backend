using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetFeedBackForTrainController : ControllerBase
    {
        private IBookingService _FeedbackForTrain;

        public GetFeedBackForTrainController(IBookingService FeedbackForTrain)
        {
            _FeedbackForTrain = FeedbackForTrain;
        }

        [HttpGet]
        public IActionResult GetFeedbacksForBus(string trainName)
        {
            var busFeedbacks = _FeedbackForTrain.GetFeedbacksForTrain(trainName);
            return Ok(busFeedbacks);
        }
    }
}
