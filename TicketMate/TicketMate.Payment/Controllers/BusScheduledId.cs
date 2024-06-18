using Microsoft.AspNetCore.Mvc;
using TicketMate.Payment.Application.BookingServices;
using TicketMate.Payment.Application.DriverService;

namespace TicketMate.Payment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusScheduledId : Controller
    {
        private readonly INotoifiBusScheduledIdService _busBookingService;

        public BusScheduledId(INotoifiBusScheduledIdService busBookingService)
        {
            _busBookingService = busBookingService;
        }

        [HttpGet("GetBusScheduleIdsByPassengerId/{passengerId}")]
        public async Task<IActionResult> GetBusScheduleIdsByPassengerId(string passengerId)
        {
            var busScheduleIds = await _busBookingService.GetBusScheduleIdsByPassengerId(passengerId);

            if (busScheduleIds == null || busScheduleIds.Count == 0)
            {
                return NotFound();
            }

            return Ok(busScheduleIds);
        }
    }

}
