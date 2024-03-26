using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketMate.Booking.Application.Services;
using TicketMate.Booking.Infrastructure;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelSearchController : ControllerBase
    {
        private IBookingService _bookingService;
            private BookingDbContext _dbContext;


        public TravelSearchController(IBookingService bookingService, BookingDbContext dbContext)
        {
            _bookingService = bookingService;
            _dbContext = dbContext;
        }



        [HttpPost]
        public async Task<IActionResult> AddTravelSearch([FromBody] TicketMate.Booking.Api.Models.TravelSearch inputTravelSearch)
        {
            try
            { /*
                if (string.IsNullOrEmpty(inputTravelSearch.VehicleType) ||
            string.IsNullOrEmpty(inputTravelSearch.StartLocation) ||
            string.IsNullOrEmpty(inputTravelSearch.EndLocation) ||
            string.IsNullOrEmpty(inputTravelSearch.TravelDate))
                {
                    return BadRequest("All fields are required.");
                }
                */

                var newTravelSearch = new TicketMate.Booking.Api.Models.TravelSearch
                {
                    VehicleType = inputTravelSearch.VehicleType,
                    StartLocation = inputTravelSearch.StartLocation,
                    EndLocation = inputTravelSearch.EndLocation,
                    TravelDate = inputTravelSearch.TravelDate

                };

                _dbContext.TravelSearch.Add(newTravelSearch);
                await _dbContext.SaveChangesAsync();

                // After saving the new travel search, automatically redirect to the GET API with the same parameters
                return RedirectToAction("GetTravelSearchResults", new
                {
                    vehicleType = newTravelSearch.VehicleType,
                    startLocation = newTravelSearch.StartLocation,
                    endLocation = newTravelSearch.EndLocation,
                    travelDate = newTravelSearch.TravelDate
                }

                    );

                // return Ok(newTravelSearch);

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex);

                // Check the inner exception for more details
                var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest($"Error while saving changes: {errorMessage}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }


        [HttpGet]
        public IActionResult GetTravelSearchResults([FromQuery] string vehicleType, [FromQuery] string startLocation, [FromQuery] string endLocation, [FromQuery] string travelDate)
        {
            try
            {
                // Retrieve search results based on vehicle type, start location, end location, and travel date
                var searchResults = _dbContext.TravelSessions
                    .Where(ts => ts.VehicleType == vehicleType && ts.StartLocation == startLocation && ts.EndLocation == endLocation && ts.TravelDate == travelDate)
                    .ToList();

                return Ok(searchResults);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
