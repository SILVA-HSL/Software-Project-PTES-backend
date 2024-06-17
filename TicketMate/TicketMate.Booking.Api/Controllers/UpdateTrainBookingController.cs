using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateTrainBookingController : ControllerBase
    {
        private IBookingService _updateTrainBooking;

        public UpdateTrainBookingController(IBookingService updateTrainBooking)
        {
            _updateTrainBooking = updateTrainBooking;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainBookedSeats(int id, [FromBody] UpdateTrainBookingDto bookingDto)
        {
            try
            {
                await _updateTrainBooking.UpdateTrainBookedSeats(id, bookingDto.BookingCarriageNo, bookingDto.BookingSeatNO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        public class UpdateTrainBookingDto
        {
            public int BookingCarriageNo { get; set; }
            public string BookingSeatNO { get; set; }
        }
    }
}
