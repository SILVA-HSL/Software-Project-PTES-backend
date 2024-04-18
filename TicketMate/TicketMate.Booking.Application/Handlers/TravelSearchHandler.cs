using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Booking.Api.Models;
using TicketMate.Booking.Application.Dtos;
using TicketMate.Booking.Domain.Dtos;
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
                throw new Exception($"Error while saving changes: {errorMessage}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //Method to get travel search results from the database
        public IEnumerable<ScheduledBuses> GetTravelSearchResults(string vehicleType, string startLocation, string endLocation, string travelDate)
        {
            try
            {
                IEnumerable<ScheduledBuses> searchResults = new List<ScheduledBuses>();

                // Check vehicle type
                if (vehicleType == "Bus")
                {
                    // Retrieve schedule ids where travel date matches the scheduled date
                    List<string> scheduleIds = _dbContext.ScheduledBusDates
     .Where(sb => sb.ScheduleDate == travelDate)
     .Select(sb => sb.ScheduledBusScheduleId)
     .ToList();


                    // Fetch all ScheduledBuses from the database
                    var allBuses = _dbContext.ScheduledBuses.Include(sb => sb.SelectedBusStands).ToList();

                    // Filter by start and end locations
                    searchResults = allBuses
                        .Where(sb => scheduleIds.Any(s => s == sb.ScheduleId) && // Compare strings directly
                                     IsSequentialBusStations(sb.SelectedBusStands, startLocation, endLocation))
                        .ToList();

                }
                else if (vehicleType == "Train")
                {
                    // Implement train search logic.
                }
                else
                {
                    throw new ArgumentException("Invalid vehicle type");
                }

                return searchResults;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving travel search results: {ex.Message}");
            }
        }



        // Helper method to check if the start location comes before the end location in the sequence of bus stations
        private bool IsSequentialBusStations(List<SelectedBusStands> busStations, string startLocation, string endLocation)
        {
            // Get the indexes of the start and end locations in the list of bus stations
            var startIndex = busStations.FindIndex(sbs => sbs.BusStation == startLocation);
            var endIndex = busStations.FindIndex(sbs => sbs.BusStation == endLocation);

            // Return true if the start location index is less than the end location index
            return startIndex != -1 && endIndex != -1 && startIndex < endIndex;
        }


        /* public IEnumerable<TravelSessions> GetTravelSearchResults(string vehicleType, string startLocation, string endLocation, string travelDate)
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
        */


        //Method to get all travel sessions from the database
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
