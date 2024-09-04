using Microsoft.AspNetCore.Mvc;
using TicketMate.Payment.Application;
using TicketMate.Payment.Application.BookingServices;
using TicketMate.Payment.Domain.Model;

namespace TicketMate.Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusBookingController : Controller
    {
        private readonly IBusBookingService _busbookingService;

        public BusBookingController(IBusBookingService busbookingService)
        {
            _busbookingService = busbookingService;
        }

        [HttpPost]
        public async Task<ActionResult<BusBookings>> CreateBooking(BusBookings booking)
        {
            var createdBooking = await _busbookingService.CreateBookingAsync(booking);
            return CreatedAtAction(nameof(CreateBooking), new { id = createdBooking.BusScheduleId }, createdBooking);
        }
    }

  
}
