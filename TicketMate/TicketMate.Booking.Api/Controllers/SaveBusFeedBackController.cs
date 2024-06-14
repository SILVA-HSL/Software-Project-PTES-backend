using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;
using TicketMate.Booking.Domain.Dtos;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveBusFeedBackController : ControllerBase
    {
        private IBookingService _busFeedBack;

        public SaveBusFeedBackController(IBookingService busFeedBack)
        {
            _busFeedBack = busFeedBack;
        }

        [HttpPost]
        public async Task<IActionResult> SaveFeedBusback ([FromBody] BusFeedbackDto feedbackDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _busFeedBack.SaveBusFeedback(feedbackDto);
            return Ok();
        }
    }
}
