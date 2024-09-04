using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteTrainFeedBackController : ControllerBase
    {
        private IBookingService _deleteTrainFeedBack;

        public DeleteTrainFeedBackController(IBookingService deleteTrainFeedBack)
        {
            _deleteTrainFeedBack = deleteTrainFeedBack;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainFeedBack(int id)
        {
            try
            {
                await _deleteTrainFeedBack.DeleteTrainFeedBack(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
