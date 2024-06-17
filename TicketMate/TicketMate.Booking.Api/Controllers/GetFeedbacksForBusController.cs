using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetFeedbacksForBusController : ControllerBase
    {
        private IBookingService _FeedbackForBus;

        public GetFeedbacksForBusController(IBookingService FeedbackForBus)
        {
            _FeedbackForBus = FeedbackForBus;
        }

        [HttpGet]
        public IActionResult GetFeedbacksForBus( int BusId)
        {
            var busFeedbacks = _FeedbackForBus.GetFeedbacksForBus(BusId);
            return Ok(busFeedbacks);
        }
    }
}
