using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Booking.Api.Models;
using TicketMate.Booking.Domain.Dtos;
using TicketMate.Booking.Domain.Models;
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
           // _context.SaveChangesAsync();

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

        public RegisteredTrainDetails GetTrainDetailsWithSeats(int schedulId)
        {
            var scheduledTrain = _context.ScheduledTrains
                .Include(st => st.ScheduledCarriages)
                    .ThenInclude(sc => sc.RegisteredCarriage)
                        .ThenInclude(rc => rc.SelCarriageSeatStructures)
                .FirstOrDefault(st => st.SchedulId == schedulId);

            if (scheduledTrain == null)
            {
                // Handle scenario where no scheduled train is found with the provided ID
                return null;
            }

            var registeredTrainDetails = new RegisteredTrainDetails
            {
                ScheduledCarriages = scheduledTrain.ScheduledCarriages,
                RegisteredCarriages = scheduledTrain.ScheduledCarriages
                    .Select(sc => sc.RegisteredCarriage)
                    .ToList(),
                SelCarriageSeatStructures = scheduledTrain.ScheduledCarriages
                    .SelectMany(sc => sc.RegisteredCarriage.SelCarriageSeatStructures)
                    .ToList()
            };

            return registeredTrainDetails;
        }

        public List<BusBooking> GetUserBusBookings(string passengerId)
        {
            return _context.BusBookings
                .Where(b => b.PassengerId == passengerId)
                .ToList();
        }

        public List<BusBooking> GetBookingsOfBusSchedule(int scheduleId, string selectedDate)
        {
            return _context.BusBookings
                .Where(b => b.BusScheduleId == scheduleId)
                .Where(b => b.BookingDate == selectedDate)
                .ToList();

        }

        public ScheduledBuses GetBusScheduleDetails(int scheduleId)
        {
            var schedule = _context.ScheduledBuses
                .Include(sb => sb.SelectedBusStands)
                .Include(sb => sb.ScheduledBusDatesList)
                .FirstOrDefault(sb => sb.ScheduleId == scheduleId);

            return schedule;
        }

        public async Task UpdateBookedSeats(int id, string bookingSeatNO)
        {
            var busBooking = await _context.BusBookings.FindAsync(id);
            if (busBooking == null)
            {
                throw new Exception("Bus booking not found");
            }

            busBooking.BookingSeatNO = bookingSeatNO;
            await _context.SaveChangesAsync();

        }

        public async Task DeleteBusBooking(int id)
        {
            var busBooking = _context.BusBookings.Find(id);
            if (busBooking == null)
            {
                throw new Exception("Bus booking not found");
            }

            _context.BusBookings.Remove(busBooking);
            await _context.SaveChangesAsync();
        }   


    }
}
