using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;
using TicketMate.Booking.Domain.Dtos;
using TicketMate.Booking.Domain.Models;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveTrainFeedbackController : ControllerBase
    {
        private IBookingService _trainFeedBack;

        public SaveTrainFeedbackController(IBookingService trainFeedBack)
        {
            _trainFeedBack = trainFeedBack;
        }

        [HttpPost]
        public async Task<IActionResult> SaveTrainFeedBack([FromBody] TrainFeedbackDto feedbackDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _trainFeedBack.SaveTrainFeedback(feedbackDto);
            return Ok();
        }
    }

}
