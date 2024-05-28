using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateBusBookingController : ControllerBase
    {
        private IBookingService _updateBusBooking;

        public UpdateBusBookingController(IBookingService updateBusBooking)
        {
            _updateBusBooking = updateBusBooking;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBusBookedSeats(int id, [FromBody] string bookingSeatNO)
        {
            try
            {
                await _updateBusBooking.UpdateBookedSeats(id, bookingSeatNO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
