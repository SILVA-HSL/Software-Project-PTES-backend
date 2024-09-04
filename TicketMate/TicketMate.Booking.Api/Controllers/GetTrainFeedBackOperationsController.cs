using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetTrainFeedBackOperationsController : ControllerBase
    {
        private IBookingService _getTrainFeedBackOperationsService;

        public GetTrainFeedBackOperationsController(IBookingService getTrainFeedBackOperationsService)
        {
            _getTrainFeedBackOperationsService = getTrainFeedBackOperationsService;
        }

        [HttpGet]
        public IActionResult GetTrainFeedBackForOperations(string passengerId, string trainName, int bookingId)
        {
            var trainFeedBackForOperations = _getTrainFeedBackOperationsService.GetTrainFeedBackForOperations(passengerId, trainName, bookingId);

            if (trainFeedBackForOperations == null)
            {
                return NotFound();
            }
            return Ok(trainFeedBackForOperations);
        }
    }
}
