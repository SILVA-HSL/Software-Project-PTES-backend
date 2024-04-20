using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Booking.Api.Models;

namespace TicketMate.Booking.Application.Services
{
    public interface IBookingService
    {
        // public List<TravelSearch> getAllLocations();

        public List<StopPoints> getAllStartLocations();

        public List<StopPoints> getAllEndLocations();

        public TravelSearch AddTravelSearch(TravelSearch inputTravelSearch);
    }
}
