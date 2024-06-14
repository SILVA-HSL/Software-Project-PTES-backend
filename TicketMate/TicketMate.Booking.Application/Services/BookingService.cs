using Microsoft.AspNetCore.Mvc;
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


        // Methods for get bus bookings of a given user
        public List<BusBooking> GetUserBusBookings(string passengerId)
        {
            return _context.BusBookings
                .Where(b => b.PassengerId == passengerId)
                 .Where(b => !b.IsCancelled)
                .ToList();
        }

        // Methods for get train bookings of a given user
        public List<TrainBooking> GetUserTrainBookings(string passengerId)
        {
            return _context.TrainBookings
               .Where(b => b.PassengerId == passengerId)
                .Where(b => !b.IsCancelled)
               .ToList();
        }

        // Methods for get bus bookings of a given schedule and given date
        public List<BusBooking> GetBookingsOfBusSchedule(int scheduleId, string selectedDate)
        {
            return _context.BusBookings
                .Where(b => b.BusScheduleId == scheduleId)
                .Where(b => b.BookingDate == selectedDate)
                 .Where(b => !b.IsCancelled)
                .ToList();

        }

        // Methods for get train bookings of a given schedule and given date
        public List<TrainBooking> GetBookingsOfTrainSchedule(int scheduleId, string selectedDate)
        {
            return _context.TrainBookings
                .Where(b => b.TrainScheduleId == scheduleId)
                .Where(b => b.BookingDate == selectedDate)
                 .Where(b => !b.IsCancelled)
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

        public List<ScheduledTrains> GetTrainScheduleDetails(int scheduleId)
        {
            return _context.ScheduledTrains
                .Where(b => b.SchedulId == scheduleId)
                .ToList();
        }

        // Upadate bus booking seats
        public async Task UpdateBusBookedSeats(int id, string bookingSeatNO)
        {
            var busBooking = await _context.BusBookings.FindAsync(id);
            if (busBooking == null)
            {
                throw new Exception("Bus booking not found");
            }

            busBooking.BookingSeatNO = bookingSeatNO;
            await _context.SaveChangesAsync();

        }

        // Upadate train booking seats
        public async Task UpdateTrainBookedSeats(int id, int bookingCarriageNo, string bookingSeatNO)
        {
            var trainBooking = await _context.TrainBookings.FindAsync(id);
            if (trainBooking == null)
            {
                throw new Exception("Train booking not found");
            }

            trainBooking.BookingCarriageNo = bookingCarriageNo;
            trainBooking.BookingSeatNO = bookingSeatNO;
            await _context.SaveChangesAsync();
        }

        
        // Delete Bus booking

        public async Task DeleteBusBooking(int id)
        {
            var busBooking = _context.BusBookings.Find(id);
            if (busBooking == null)
            {
                throw new Exception("Bus booking not found");

            }
            busBooking.IsCancelled = true; // Set IsCancelled to true

            _context.BusBookings.Update(busBooking); // Remove the bus booking from the table
            await _context.SaveChangesAsync();
        }


        public async Task DeleteTrainBooking(int id)
        {
            var trainBooking = _context.TrainBookings.Find(id);
            if (trainBooking == null)
            {
                throw new Exception("Bus booking not found");
            }
            trainBooking.IsCancelled = true; // Set IsCancelled to true

            _context.TrainBookings.Update(trainBooking); // Remove the booking from the table
            await _context.SaveChangesAsync();
        }

        public async Task SaveBusFeedback(BusFeedbackDto feedbackDto)
        {
            var feedback = new BusFeedBack
            {
                BusId = feedbackDto.BusId,
                BookingId = feedbackDto.BookingId,
                PassengerId = feedbackDto.PassengerId,
                Rate = feedbackDto.Rate,
                FeedBack = feedbackDto.FeedBack,
                GivenDate = DateTime.Parse(feedbackDto.GivenDate).ToString("yyyy-MM-dd")
            };

            _context.BusFeedBacks.Add(feedback);
            await _context.SaveChangesAsync();
        }

        public List<BusFeedBack> GetBusFeedBackForOperations(string passengerId, int busId, int bookingId)
        {
            return _context.BusFeedBacks
                .Where(b => b.PassengerId == passengerId)
                .Where(b => b.BusId == busId)
                .Where(b => b.BookingId == bookingId)
                .ToList();
        }

        public List<TrainFeedBack> GetTrainFeedBackForOperations(string passengerId, string trainName , int bookingId)
        {
            return _context.TrainFeedBacks
                .Where(b => b.PassengerId == passengerId)
                .Where(b => b.TrainName == trainName)
                .Where(b => b.BookingId == bookingId)
                .ToList();
        }

        public async Task DeleteBusFeedBack(int id)
        {
            var busFeedBack = _context.BusFeedBacks.Find(id);

            if (busFeedBack == null)
            {
                throw new Exception("Bus booking not found");
            }

            _context.BusFeedBacks.Remove(busFeedBack);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTrainFeedBack(int id)
        {
            var trainFeedBack = _context.TrainFeedBacks.Find(id);

            if (trainFeedBack == null)
            {
                throw new Exception("Bus booking not found");
            }

            _context.TrainFeedBacks.Remove(trainFeedBack);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBusFeedBack(int id, [FromBody] string feedback, decimal rate)
        {
            var busFeedBack1 = await _context.BusFeedBacks.FindAsync(id);
            if (busFeedBack1 == null)
            {
                throw new Exception("Bus booking not found");
            }

            busFeedBack1.FeedBack = feedback;
            busFeedBack1.Rate = rate;
            await _context.SaveChangesAsync();
        }

        public List<BusFeedBack> GetFeedbacksForBus(int BusId)
        {
            return _context.BusFeedBacks
                .Where(b => b.BusId == BusId)
                .ToList();
        }

        public List<TrainFeedBack> GetFeedbacksForTrain(string trainName)
        {
            return _context.TrainFeedBacks
                .Where(b => b.TrainName == trainName)
                .ToList();
        }

        public List<AspNetUsers> GetUserName(string UserId)
        {
            return _context.AspNetUsers
                .Where(b => b.Id == UserId)
                .ToList();
        }

        public List<ScheduledTrains> GetTrainName(int trainScheduleId)
        {
            return _context.ScheduledTrains
                .Where(b => b.SchedulId == trainScheduleId)
                .ToList();
        }

        public async Task SaveTrainFeedback(TrainFeedbackDto feedbackDto)
        {
            var feedback = new TrainFeedBack
            {
                TrainScheduleId = feedbackDto.TrainScheduleId,
                BookingId = feedbackDto.BookingId,
                PassengerId = feedbackDto.PassengerId,
                TrainName = feedbackDto.TrainName,
                Rate = feedbackDto.Rate,
                FeedBack = feedbackDto.FeedBack,
                GivenDate = DateTime.Parse(feedbackDto.GivenDate).ToString("yyyy-MM-dd")
            };

            _context.TrainFeedBacks.Add(feedback);
            await _context.SaveChangesAsync();
        }


    }
}
