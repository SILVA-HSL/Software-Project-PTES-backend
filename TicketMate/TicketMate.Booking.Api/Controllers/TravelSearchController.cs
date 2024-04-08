using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketMate.Booking.Application.Handlers;
using TicketMate.Booking.Application.Services;
using TicketMate.Booking.Infrastructure;

namespace TicketMate.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelSearchController : ControllerBase
    {

        private readonly TravelSearchHandler _travelSearchHandler;


        public TravelSearchController(TravelSearchHandler travelSearchHandler)
        {

            _travelSearchHandler = travelSearchHandler;
        }



        [HttpPost]
        public async Task<IActionResult> AddTravelSearch([FromBody] TicketMate.Booking.Api.Models.TravelSearch inputTravelSearch)
        {
            try
            {

                var newTravelSearch = await _travelSearchHandler.AddTravelSearch(inputTravelSearch);



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
                var searchResults = _travelSearchHandler.GetTravelSearchResults(vehicleType, startLocation, endLocation, travelDate);
                    

                return Ok(searchResults);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
