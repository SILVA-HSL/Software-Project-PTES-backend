using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Booking.Api.Models;
using TicketMate.Booking.Infrastructure;

namespace TicketMate.Booking.Application.Handlers
{
    public class TravelSearchHandler
    {
        private readonly BookingDbContext _dbContext;

        public TravelSearchHandler(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TravelSearch> AddTravelSearch(TicketMate.Booking.Api.Models.TravelSearch inputTravelSearch)
        {
            try
            {
                var newTravelSearch = new TicketMate.Booking.Api.Models.TravelSearch
                {
                    VehicleType = inputTravelSearch.VehicleType,
                    StartLocation = inputTravelSearch.StartLocation,
                    EndLocation = inputTravelSearch.EndLocation,
                    TravelDate = inputTravelSearch.TravelDate
                };

                _dbContext.TravelSearch.Add(newTravelSearch);
                await _dbContext.SaveChangesAsync();

                return newTravelSearch;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex);
                var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                throw new Exception ($"Error while saving changes: {errorMessage}");
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        public IEnumerable<TravelSessions> GetTravelSearchResults(string vehicleType, string startLocation, string endLocation, string travelDate)
        {
            try
            {
                var searchResults = _dbContext.TravelSessions
                    .Where(ts => ts.VehicleType == vehicleType && ts.StartLocation == startLocation && ts.EndLocation == endLocation && ts.TravelDate == travelDate)
                    .ToList();

                return searchResults;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving travel search results: {ex.Message}");
            }
        }

        public IEnumerable<TravelSessions> GetAllTravelSearchResults()
        {
            try
            {
                var allSearchResults = _dbContext.TravelSessions.ToList();
                return allSearchResults;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving all travel search results: {ex.Message}");
            }
        }
    }
}
