using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Booking.Api.Models;
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

        /* public List<TravelSearch> getAllLocations()
         {
             return _context.TravelSearch.ToList();
         }*/


        public List<StopPoints> getAllStartLocations()
        {
            return _context.SelectedBusStands.Select(x => new StopPoints
            {
                StopName = x.BusStation
            }).ToList();
        }


        public List<StopPoints> getAllEndLocations()
        {
            return _context.SelectedBusStands.Select(x => new StopPoints
            {
                StopName = x.BusStation
            })
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

    }
}
