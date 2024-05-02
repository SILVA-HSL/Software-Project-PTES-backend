using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Booking.Api.Models;
using TicketMate.Booking.Domain.Dtos;
using TicketMate.Booking.Infrastructure;

namespace TicketMate.Booking.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly BookingDbContext _context;

        public BookingService(BookingDbContext context)
        {
            _context = context;
        }

        public List<BusRouteStands> getAllBusStands()
        {
            return _context.BusRouteStands
                .Select(x => new BusRouteStands
                {
                    StandName = x.StandName
                }
                )
                .ToList();

        }


        public List<TrainRaliwayStations> getAllTrainStations()
        {
            return _context.TrainRaliwayStations
                .Select(x => new TrainRaliwayStations
                {
                    TrainStationName = x.TrainStationName
                }
                )
                .ToList();
        }


        public TravelSearch AddTravelSearch(TravelSearch inputTravelSearch)
        {

            var newTravelSearch = new TravelSearch
            {
                VehicleType = inputTravelSearch.VehicleType,
                StartLocation = inputTravelSearch.StartLocation,
                EndLocation = inputTravelSearch.EndLocation,
                TravelDate = inputTravelSearch.TravelDate
            };

            _context.TravelSearch.Add(newTravelSearch);
            _context.SaveChangesAsync();

            return newTravelSearch;


        }

        public RegisteredBusDetails GetBusDetailsWithSeats(int registeredBusBusId)
        {
            var registeredBusWithSeats = _context.RegisteredBuses
                .Include(bus => bus.SelectedSeatStructures)
                .FirstOrDefault(bus => bus.BusId == registeredBusBusId);

            if (registeredBusWithSeats == null)
            {
                // Handle scenario where no bus is found with the provided ID
                return null;
            }

            var busDetailsDto = new RegisteredBusDetails
            {
                RegisteredBus = registeredBusWithSeats,
                SelectedSeatStructures = registeredBusWithSeats.SelectedSeatStructures
            };

            return busDetailsDto;
        }

    }
}
