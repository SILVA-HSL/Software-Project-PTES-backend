using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetTrainStationsController : ControllerBase
    {
        private IBookingService _trainService;

        public GetTrainStationsController(IBookingService trainService)
        {
            _trainService = trainService;
        }

        [HttpGet]
        public IActionResult getAllTrainStations()
        {
            var trainStations = _trainService.getAllTrainStations();
            return Ok(trainStations);
        }
    }
}
