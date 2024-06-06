using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;
using TicketMate.Booking.Domain.Dtos;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateBusFeedBackController : ControllerBase
    {
        private IBookingService _updateBusFeedBack;

        public UpdateBusFeedBackController(IBookingService updateBusFeedBack)
        {
            _updateBusFeedBack = updateBusFeedBack;
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateBusFeedBack(int id, [FromBody] UpdateBusFeedBackDto updateBusFeedBackDto)
        {
            try
            {
                await _updateBusFeedBack.UpdateBusFeedBack(id, updateBusFeedBackDto.feedback, updateBusFeedBackDto.rate);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
