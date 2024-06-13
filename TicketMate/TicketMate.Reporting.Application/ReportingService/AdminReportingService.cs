using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Reporting.Domain.Dtos;
using TicketMate.Reporting.Domain.Models;
using TicketMate.Reporting.Infrastructure;

namespace TicketMate.Reporting.Application.ReportingService
{
    public class AdminReportingService : IAdminReportingService
    {
        private readonly ReportingDbContext _context;

        public AdminReportingService(DbContextOptions<ReportingDbContext> dbContextOptions)
        {
            _context = new ReportingDbContext(dbContextOptions);
        }

        public AdminReportDTO GetStatistics(string userId, DateTime startDate, DateTime endDate)
        {
            // Fetch the registered bus details for the user
            var registeredBuses = _context.RegisteredBuses
                .Where(rb => rb.UserId == userId && rb.DeleteState)
                .ToList();

            var vehicleNoList = registeredBuses.Select(rb => rb.BusId).ToList();

            // Convert startDate and endDate to strings in "yyyy-MM-dd" format
            string startDateString = startDate.ToString("yyyy-MM-dd");
            string endDateString = endDate.ToString("yyyy-MM-dd");

            // Fetch bookings for the registered buses within the date range
            var bookings = _context.BusBookings
                .Where(b => vehicleNoList.Contains(b.BusId) &&
                            string.Compare(b.PaymentDate, startDateString) >= 0 &&
                            string.Compare(b.PaymentDate, endDateString) <= 0)
                .ToList();

            var totalIncome = bookings.Sum(b => b.TotalPaymentAmount);
            var totalPassengers = bookings.Sum(b => int.Parse(b.BookingSeatCount));

            // Fetch feedback for the registered buses
            var feedbacks = _context.BusFeedBacks
                .Where(f => vehicleNoList.Contains(f.BusId))
                .ToList();

            var averageRate = feedbacks.Any() ? feedbacks.Average(f => f.Rate) : 0;

            return new AdminReportDTO
            {
                VehicleOwner = userId,
                VehicleNo = string.Join(", ", registeredBuses.Select(rb => rb.BusNo)),
                TotalIncome = totalIncome,
                TotalPassengers = totalPassengers,
                Date = endDate,
                AverageRate = (double)averageRate
            };
        }

        public List<string> GetBusOwnerUserIds()
        {
            return _context.RegisteredBuses
                .Where(rb => rb.DeleteState == true)
                .Select(rb => rb.UserId)
                .Distinct()
                .ToList();
        }
    }
}

