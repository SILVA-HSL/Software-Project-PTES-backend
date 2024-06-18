using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Reporting.Domain.Dtos;
using TicketMate.Reporting.Infrastructure;

namespace TicketMate.Reporting.Application.ReportingService
{
    public class BusOwnerReportingService: IBusOwnerReportingService
    {
        private readonly ReportingDbContext _context;

        public BusOwnerReportingService(DbContextOptions<ReportingDbContext> dbContextOptions)
        {
            _context = new ReportingDbContext(dbContextOptions);
        }
        public async Task<List<OwnerReportDTO>> GetOwnerReportAsync(string userId)
        {
            var today = DateTime.Today;
            return await GenerateReportAsync(userId, today, today);
        }

        public async Task<List<OwnerReportDTO>> GetMonthlyOwnerReportAsync(string userId)
        {
            var today = DateTime.Today;
            var startDate = new DateTime(today.Year, today.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            return await GenerateReportAsync(userId, startDate, endDate);
        }

        public async Task<List<OwnerReportDTO>> GetQuarterlyOwnerReportAsync(string userId)
        {
            var today = DateTime.Today;
            var currentQuarter = (today.Month - 1) / 3 + 1;
            var startDate = new DateTime(today.Year, (currentQuarter - 1) * 3 + 1, 1);
            var endDate = startDate.AddMonths(3).AddDays(-1);
            return await GenerateReportAsync(userId, startDate, endDate);
        }

        public async Task<List<OwnerReportDTO>> GetYearlyOwnerReportAsync(string userId)
        {
            var today = DateTime.Today;
            var startDate = new DateTime(today.Year, 1, 1);
            var endDate = startDate.AddYears(1).AddDays(-1);
            return await GenerateReportAsync(userId, startDate, endDate);
        }

        private async Task<List<OwnerReportDTO>> GenerateReportAsync(string userId, DateTime startDate, DateTime endDate)
        {
            string startDateString = startDate.ToString("yyyy-MM-dd");
            string endDateString = endDate.ToString("yyyy-MM-dd");
            var today = DateTime.Today;


            var registeredBuses = await _context.RegisteredBuses
                                                .Where(bus => bus.UserId == userId && bus.DeleteState)
                                                .ToListAsync();

            var busIds = registeredBuses.Select(bus => bus.BusId).ToList();


            var bookings = await _context.BusBookings
                                         .Where(booking => busIds.Contains(booking.BusId) &&
                                                          !booking.IsCancelled && // Ensure booking is not cancelled

                                                           string.Compare(booking.PaymentDate, startDateString) >= 0 &&
                                                           string.Compare(booking.PaymentDate, endDateString) <= 0)
                                         .ToListAsync();

            var feedbacks = await _context.BusFeedBacks
                                          .Where(feedback => busIds.Contains(feedback.BusId) &&
                                                             string.Compare(feedback.GivenDate, startDateString) >= 0 &&
                                                             string.Compare(feedback.GivenDate, endDateString) <= 0)
                                          .ToListAsync();

           
            // Fetching predictions for the buses for today
            var predictions = await _context.DailyBusPredictions
                                            .Where(p => busIds.Contains(p.BusId) &&
                                                        p.PredictionDate.Date == today)
                                            .Select(p => new { p.BusId, p.PredictedIncome })
                                            .ToListAsync();

    

            // Creating the report for each registered bus
            var report = registeredBuses.Select(bus => {
                // Summing predicted income for the current bus
                var predictedIncome = predictions
                    .Where(p => p.BusId == bus.BusId)
                    .Sum(p => p.PredictedIncome);

                // Creating a new report DTO for the current bus
        return new OwnerReportDTO
        {
            BusId = bus.BusId,
            VehicleOwner = userId,
            VehicleNo = bus.BusNo,
            TotalIncome = bookings
                .Where(b => b.BusId == bus.BusId)
                .Sum(b => b.TotalPaymentAmount),
            TotalPassengers = bookings
                .Where(b => b.BusId == bus.BusId)
                .Count(),
            Date = startDate,
            AverageRate = feedbacks
                .Where(f => f.BusId == bus.BusId)
                .Average(f => (double?)f.Rate) ?? 0,
            MonthlyPredictedIncome = predictedIncome
        };
            }).ToList();

            return report;
        }
    }
}
