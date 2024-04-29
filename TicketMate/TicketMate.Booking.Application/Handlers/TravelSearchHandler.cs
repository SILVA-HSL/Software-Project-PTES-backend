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


        public IEnumerable<object> GetTravelSearchResults(string VehicleType, string StartLocation, string EndLocation, string TravelDate)
        {
            try
            {


                if (VehicleType == "Bus")
                {
                    return GetBusTravelSearchResults(StartLocation, EndLocation, TravelDate);
                }
                else if (VehicleType == "Train")
                {
                    return GetTrainTravelSearchResults(StartLocation, EndLocation, TravelDate);
                }
                else
                {
                    throw new ArgumentException("Invalid vehicle type");
                }


            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving travel search results: {ex.Message}");
            }
        }

        //Method to get bus travel search results from the database
        public IEnumerable<ScheduledBuses> GetBusTravelSearchResults(string startLocation, string endLocation, string travelDate)
        {
            try
            {
                IEnumerable<ScheduledBuses> searchResult = new List<ScheduledBuses>();



                // Retrieve schedule ids where travel date matches the scheduled date
                List<int> scheduleIds = _dbContext.ScheduledBusDates
                    .Where(sb => sb.DepartureDate == travelDate)
                    .Select(sb => sb.ScheduledBusScheduleId)
                    .ToList();


                // Fetch all ScheduledBuses from the database
                var allBuses = _dbContext.ScheduledBuses
                    .Include(sb => sb.SelectedBusStands)
                    .Include(sb => sb.ScheduledBusDatesList)
                    .ToList();

                // Filter by start and end locations
                searchResult = allBuses
                    .Where(sb => scheduleIds.Any(s => s == sb.ScheduleId) &&
                                 IsSequentialBusStations(sb.SelectedBusStands, startLocation, endLocation))


                    .ToList();
                return searchResult;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving travel search results: {ex.Message}");
            }

        }


        //Method to get train travel search results from the database
        public IEnumerable<object> GetTrainTravelSearchResults(string startLocation, string endLocation, string travelDate)
        {
            try
            {
                List<object> searchResult = new List<object>();

                // Retrieve schedule ids where travel date matches the scheduled date for trains
                List<int> scheduleIds = _dbContext.ScheduledTrainDates
                    .Where(std => std.DepartureDate == travelDate)
                    .Select(std => std.ScheduledTrainSchedulId)
                    .ToList();

                // Fetch all ScheduledTrains from the database
                var allTrains = _dbContext.ScheduledTrains
                    .Include(st => st.SelectedTrainStations)
                    .Include(st => st.ScheduledTrainDates) // Include ScheduledTrainDates
                    .ToList();

                // Filter by start and end locations
                var filteredTrains = allTrains
                    .Where(st => scheduleIds.Contains(st.SchedulId) &&
                                 IsSequentialTrainStations(st.SelectedTrainStations, startLocation, endLocation))
                    .ToList();

                // Populate response for each train
                foreach (var train in filteredTrains)
                {
                    var selectedStations = train.SelectedTrainStations
                        .OrderBy(station => station.id) // Order by the station ID to ensure correct sequence
                        .Select(station => new
                        {
                            station.id,
                            station.TrainStationName,
                            station.TrainDepartureTime
                        })
                        .ToList();

                    var trainDates = train.ScheduledTrainDates
                         .Where(date => date.DepartureDate == travelDate) // Filter by the travel date
                         .Select(date => new
                         {
                             date.ArrivalDate,
                             date.DepartureDate
                         })
                         .FirstOrDefault(); // Get the first matching date

                    var trainResponse = new
                    {
                        train.SchedulId,
                        train.TrainRoutNo,
                        train.StartStation,
                        train.EndStation,
                        train.TrainDepartureTime,
                        train.TrainArrivalTime,
                        train.Duration,
                        train.TrainType,
                        train.FirstClassTicketPrice,
                        train.SecondClassTicketPrice,
                        stopStations = selectedStations, // Include the stop stations in the response
                        trainDates // Include the train dates in the response
                    };

                    searchResult.Add(trainResponse);
                }

                return searchResult;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving travel search results: {ex.Message}");
            }
        }
       
        // Helper method to check if the start location comes before the end location in the sequence of bus stands
        private bool IsSequentialBusStations(List<SelectedBusStands> busStations, string startLocation, string endLocation)
        {
            // Get the indexes of the start and end locations in the list of bus stations
            var startIndex = busStations.FindIndex(sbs => sbs.BusStation == startLocation);
            var endIndex = busStations.FindIndex(sbs => sbs.BusStation == endLocation);

            // Return true if the start location index is less than the end location index
            return startIndex != -1 && endIndex != -1 && startIndex < endIndex;
        }

        // Helper method to check if the start location comes before the end location in the sequence of train stations
        private bool IsSequentialTrainStations(List<SelectedTrainStations> trainStations, string startLocation, string endLocation)
        {
            // Get the indexes of the start and end locations in the list of train stations
            var startIndex = trainStations.FindIndex(sts => sts.TrainStationName == startLocation);
            var endIndex = trainStations.FindIndex(sts => sts.TrainStationName == endLocation);

            // Return true if the start location index is less than the end location index
            return startIndex != -1 && endIndex != -1 && startIndex < endIndex;
        }

    }
}
