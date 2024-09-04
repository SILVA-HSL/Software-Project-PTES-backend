using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        private readonly HttpClient _httpClient;



        public AdminReportingService(DbContextOptions<ReportingDbContext> dbContextOptions, HttpClient httpClient)
        {
            _context = new ReportingDbContext(dbContextOptions);
            _httpClient = httpClient;

        }

        // Added method to ensure predictions are available
        public async Task EnsurePredictionsAreAvailableAsync()
        {
            var today = DateTime.Today;
            bool predictionsExist = _context.DailyBusPredictions.Any(p => p.PredictionDate.Date == today);

            if (!predictionsExist)
            {
                // Call the prediction endpoint
                var response = await _httpClient.GetAsync("http://localhost:5050/api/BusPrediction/predict");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to generate predictions.");
                }
            }
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

            var today = DateTime.Today;

            //var monthlyTotalPredictedIncome = _context.DailyBusPredictions
            // .Where(p => p.UserId == userId && p.PredictionDate.Date == today)
            // .Sum(p => p.PredictedIncome);
            var monthlyTotalPredictedIncome = _context.DailyBusPredictions
              .Where(p => p.UserId == userId && p.PredictionDate.Date == today && p.PredictedIncome >= 0)
              .Sum(p => p.PredictedIncome);


            var averageRate = feedbacks.Any() ? feedbacks.Average(f => f.Rate) : 0;

            return new AdminReportDTO
            {
                VehicleOwner = userId,
                VehicleNo = string.Join(", ", registeredBuses.Select(rb => rb.BusNo)),
                TotalIncome = totalIncome,
                TotalPassengers = totalPassengers,
                Date = endDate,
                AverageRate = (double)averageRate,
                MonthlyTotalPredictedIncome = monthlyTotalPredictedIncome
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

        public List<string> GetTrainOwnerUserIds()
        {
            return _context.ScheduledTrains
                .Where(rb => rb.DeleteState == true)
                .Select(rb => rb.UserId)
                .Distinct()
                .ToList();
        }
        public async Task<string> GetTotalPredictedIncomeForUserAsync(string userId)
        {

            await EnsurePredictionsAreAvailableAsync();

            var today = DateTime.Today;

            var userExists = _context.DailyBusPredictions
        .Any(p => p.UserId == userId);

            if (!userExists)
            {
                return $"User with ID {userId} does not exist.";
            }

            // Retrieve the cached prediction data
            var totalIncome = _context.DailyBusPredictions
                .Where(p => p.UserId == userId && p.PredictionDate.Date == today)
                .Sum(p => p.PredictedIncome);

            return totalIncome.ToString("F2");
        }



    }
}

