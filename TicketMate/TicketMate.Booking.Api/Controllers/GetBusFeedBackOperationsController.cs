using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TicketMate.Booking.Application.Services;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetBusFeedBackOperationsController : ControllerBase
    {
        private IBookingService _getBusFeedBackOperationsService;

        public GetBusFeedBackOperationsController(IBookingService getBusFeedBackOperationsService)
        {
            _getBusFeedBackOperationsService = getBusFeedBackOperationsService;
        }

        [HttpGet]
        public IActionResult GetBusFeedBackForOperations(string passengerId, int busId, int bookingId)
        {
            var busFeedBackForOperations = _getBusFeedBackOperationsService.GetBusFeedBackForOperations(passengerId, busId, bookingId);

            if (busFeedBackForOperations == null)
            {
                return NotFound();
            }
            return Ok(busFeedBackForOperations);
        }   
    }
}
