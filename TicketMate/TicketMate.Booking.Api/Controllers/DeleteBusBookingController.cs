using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteBusBookingController : ControllerBase
    {
        private IBookingService _deleteBusBooking;

        public DeleteBusBookingController(IBookingService deleteBusBooking)
        {
            _deleteBusBooking = deleteBusBooking;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusBooking(int id)
        {
            try
            {
                await _deleteBusBooking.DeleteBusBooking(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
