using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteBusFeedBackController : ControllerBase
    {
        private IBookingService _deleteBusFeedBack;

        public DeleteBusFeedBackController(IBookingService deleteBusFeedBack)
        {
            _deleteBusFeedBack = deleteBusFeedBack;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusFeedBack(int id)
        {
            try
            {
                await _deleteBusFeedBack.DeleteBusFeedBack(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
