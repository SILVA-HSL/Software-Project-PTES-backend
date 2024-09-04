using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserNameController : ControllerBase
    {
        private IBookingService _userName;

        public GetUserNameController(IBookingService userName)
        {
            _userName = userName;
        }

        [HttpGet]
        public IActionResult GetUserName(int UserId)
        {
            var userName = _userName.GetUserName(UserId);
            return Ok(userName);
        }
    }
}
