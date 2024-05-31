using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Booking.Api.Models;
using TicketMate.Booking.Domain.Dtos;
using TicketMate.Booking.Domain.Models;

namespace TicketMate.Booking.Application.Services
{
    public interface IBookingService
    {
        public List<BusRouteStands> getAllBusStands();

        public List<TrainRaliwayStations> getAllTrainStations();

        public TravelSearch AddTravelSearch(TravelSearch inputTravelSearch);

        public RegisteredBusDetails GetBusDetailsWithSeats(int registeredBusBusId);

        public RegisteredTrainDetails GetTrainDetailsWithSeats(int SchedulId);

        public List<BusBooking> GetUserBusBookings(string passengerId);

        public List<TrainBooking> GetUserTrainBookings(string passengerId);

        public List<BusBooking> GetBookingsOfBusSchedule(int scheduleId, string selectedDate);

        public List<TrainBooking> GetBookingsOfTrainSchedule(int scheduleId, string selectedDate);

        public ScheduledBuses GetBusScheduleDetails(int scheduleId);

        public List<ScheduledTrains> GetTrainScheduleDetails(int scheduleId);

        public  Task UpdateBusBookedSeats(int id, string bookingSeatNO);

        public Task DeleteBusBooking(int id);

    }
}
