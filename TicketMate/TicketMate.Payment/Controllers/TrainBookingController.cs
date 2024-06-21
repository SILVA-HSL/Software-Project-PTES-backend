using Microsoft.AspNetCore.Mvc;
using TicketMate.Payment.Application.BookingServices;
using TicketMate.Payment.Domain.Model;

namespace TicketMate.Payment.Api.Controllers
{
    
    
        [Route("api/[controller]")]
        [ApiController]
        public class TrainBookingController : Controller
        {
            private readonly ITrainBookingService _trainBookingService;

            public TrainBookingController(ITrainBookingService trainBookingService)
            {
                _trainBookingService = trainBookingService;
            }

            [HttpPost]
            public async Task<ActionResult<TrainBookings>> CreateBooking(TrainBookings booking)
            {
                var createdBooking = await _trainBookingService.CreateBookingAsync(booking);
                return CreatedAtAction(nameof(CreateBooking), new { id = createdBooking.TrainScheduleId }, createdBooking);
            }
        }
    }

