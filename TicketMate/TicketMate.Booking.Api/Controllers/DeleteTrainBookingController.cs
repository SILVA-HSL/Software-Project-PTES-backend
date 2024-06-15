using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteTrainBookingController : ControllerBase
    {
        private IBookingService _deleteTrainBooking;

        public DeleteTrainBookingController(IBookingService deleteTrainBooking)
        {
            _deleteTrainBooking = deleteTrainBooking;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainBooking(int id)
        {
            try
            {
                await _deleteTrainBooking.DeleteTrainBooking(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
