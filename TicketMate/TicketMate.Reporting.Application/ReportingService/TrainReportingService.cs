using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Reporting.Domain.Dtos;
using TicketMate.Reporting.Infrastructure;

namespace TicketMate.Reporting.Application.ReportingService
{
    public class TrainReportingService: ITrainReportingService
    {
        private readonly ReportingDbContext _context;

        public TrainReportingService(DbContextOptions<ReportingDbContext> dbContextOptions)
        {
            _context = new ReportingDbContext(dbContextOptions);
        }

       
        public enum DateFilter
        {
            Daily,
            Monthly,
            ThreeMonths,
            Yearly
        }

        public async Task<List<TrainReportDTO>> GenerateTrainReportAsync(string userId, DateFilter dateFilter)
        {
            DateTime today = DateTime.Today;
            DateTime startDate = today;
            DateTime endDate = today;

            // Determine the date range based on the filter
            switch (dateFilter)
            {
                case DateFilter.Daily:
                    // already set as today
                    break;
                case DateFilter.Monthly:
                    startDate = new DateTime(today.Year, today.Month, 1);
                    endDate = startDate.AddMonths(1).AddDays(-1);
                    break;
                case DateFilter.ThreeMonths:
                    startDate = new DateTime(today.Year, today.Month, 1).AddMonths(-2);
                    endDate = startDate.AddMonths(3).AddDays(-1);
                    break;
                case DateFilter.Yearly:
                    startDate = new DateTime(today.Year, 1, 1);
                    endDate = new DateTime(today.Year, 12, 31);
                    break;
            }

            

            string startDateString = startDate.ToString("yyyy-MM-dd");
            string endDateString = endDate.ToString("yyyy-MM-dd");

            // Fetch all unique train names and their schedules
            var scheduledTrains = await _context.ScheduledTrains
                                                .Where(train => train.DeleteState && train.UserId == userId)
                                                .GroupBy(train => train.TrainName)
                                                .Select(group => new
                                                {
                                                    TrainName = group.Key,
                                                    ScheduleIds = group.Select(train => train.SchedulId).ToList()
                                                })
                                                .ToListAsync();

            var scheduleIds = scheduledTrains.SelectMany(train => train.ScheduleIds).ToList();

            // Fetch all valid bookings within the date range and for the active schedules
            var bookings = await _context.TrainBookings
                                         .Where(booking => scheduleIds.Contains(booking.TrainScheduleId) &&
                                                           !booking.IsCancelled &&
                                                           string.Compare(booking.PaymentDate, startDateString) >= 0 &&
                                                           string.Compare(booking.PaymentDate, endDateString) <= 0)
                                         .ToListAsync();

            // Fetch all feedbacks within the date range and for the active schedules
            var feedbacks = await _context.TrainFeedBacks
                                          .Where(feedback => scheduleIds.Contains(feedback.TrainScheduleId) &&
                                                             string.Compare(feedback.GivenDate, startDateString) >= 0 &&
                                                             string.Compare(feedback.GivenDate, endDateString) <= 0)
                                          .ToListAsync();

            // Fetch predicted monthly income for each train for the current date
            var predictedIncomes = await _context.DailyTrainPredictions
                                                .Where(prediction => prediction.PredictionDate == today)
                                                .ToListAsync();

            // Generate report data for each unique train
            var report = new List<TrainReportDTO>();

            foreach (var train in scheduledTrains)
            {
                var totalIncome = bookings
                    .Where(b => train.ScheduleIds.Contains(b.TrainScheduleId))
                    .Sum(b => b.TotalPaymentAmount);

                var totalPassengers = bookings
                    .Where(b => train.ScheduleIds.Contains(b.TrainScheduleId))
                    .Sum(b => int.Parse(b.BookingSeatCount));

                var averageRate = feedbacks
                    .Where(f => train.ScheduleIds.Contains(f.TrainScheduleId))
                    .Average(f => (double?)f.Rate) ?? 0;


                var monthlyPredictedIncome = predictedIncomes
                   .Where(prediction => prediction.TrainName == train.TrainName)
                   .Select(prediction => prediction.PredictedIncome)
                   .FirstOrDefault(); // Assuming there's only one prediction per train name per day


                var trainReport = new TrainReportDTO
                {
                    TrainName = train.TrainName,
                    ScheduleIds = train.ScheduleIds.ToList(),  // Change to include all ScheduleIds
                    TotalIncome = totalIncome,
                    TotalPassengers = totalPassengers,
                    MonthlyPredictedIncome = monthlyPredictedIncome,
                    AverageRate = averageRate,
                    Date= today,
                    UserId=userId
                };

                report.Add(trainReport);
            }

            return report;
        }


        public List<string> GetTrainOwnerUserIds()
        {
            return _context.ScheduledTrains
                .Where(rb => rb.DeleteState == true)
                .Select(rb => rb.UserId)
                .Distinct()
                .ToList();
        }


    }
}
