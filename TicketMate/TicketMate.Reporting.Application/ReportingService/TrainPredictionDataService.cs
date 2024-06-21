using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Reporting.Domain.Dtos;
using TicketMate.Reporting.Infrastructure;

namespace TicketMate.Reporting.Application.ReportingService
{
    public class TrainPredictionDataService:ITrainPredictionDataService
    {
        private readonly ReportingDbContext _context;

        public TrainPredictionDataService(DbContextOptions<ReportingDbContext> dbContextOptions)
        {
            _context = new ReportingDbContext(dbContextOptions);
        }


        public List<TrainPredictionInputDTO> GetPredictionDataForAllTrains()
        {
            List<TrainPredictionInputDTO> predictionDataList = new List<TrainPredictionInputDTO>();

            // Get all unique train names
            var trainNames = GetUniqueTrainNames();

            foreach (var trainName in trainNames)
            {
                var trainData = GetTrainData(trainName);

                if (trainData != null)
                {
                    predictionDataList.Add(trainData);
                }
            }

            return predictionDataList;
        }

        public List<string> GetUniqueTrainNames()
        {
            return _context.ScheduledTrains
                .Where(train => train.DeleteState)
                .Select(train => train.TrainName)
                .Distinct()
                .ToList();
        }

        public TrainPredictionInputDTO GetTrainData(string trainName)
        {
            var scheduledTrains = _context.ScheduledTrains
                .Where(train => train.TrainName == trainName && train.DeleteState)
                .ToList();

            var firstScheduledTrain = scheduledTrains.FirstOrDefault();

            if (firstScheduledTrain == null) return null;

            var scheduleIds = scheduledTrains.Select(t => t.SchedulId).ToList();
            var previousMonthIncome = CalculatePreviousMonthIncome(scheduleIds);
            var (monthlyBookedAcSeats, monthlyBookedNonAcSeats) = CalculateMonthlyBookedSeats(scheduleIds);
            var (numberOfRides, workingDays) = CalculateRidesAndWorkingDays(scheduleIds);
            var (availableAcSeats, availableNonAcSeats) = CalculateAvailableSeats(scheduleIds);

            return new TrainPredictionInputDTO
            {
                TrainName = firstScheduledTrain.TrainName,
                AcSeatCount = availableAcSeats,
                NonAcSeatCount = availableNonAcSeats,
                TicketPrice = (double)firstScheduledTrain.FirstClassTicketPrice,
                MonthlyBookedAcSeats = monthlyBookedAcSeats,
                MonthlyBookedNonAcSeats = monthlyBookedNonAcSeats,
                NumberOfRides = numberOfRides,
                WorkingDays = workingDays,
                PreviousMonthIncome = previousMonthIncome,
                TrainType = firstScheduledTrain.TrainType == "Express" ? 1 : 0
            };
        }

        private decimal CalculatePreviousMonthIncome(List<int> scheduleIds)
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfPreviousMonth = new DateTime(today.Year, today.Month, 1).AddMonths(-1);
            DateTime lastDayOfPreviousMonth = firstDayOfPreviousMonth.AddMonths(1).AddDays(-1);

            string startDateString = firstDayOfPreviousMonth.ToString("yyyy-MM-dd");
            string endDateString = lastDayOfPreviousMonth.ToString("yyyy-MM-dd");

            return _context.TrainBookings
                .Where(booking => scheduleIds.Contains(booking.TrainScheduleId)
                                  && !booking.IsCancelled
                                  && String.Compare(booking.PaymentDate, startDateString) >= 0
                                  && String.Compare(booking.PaymentDate, endDateString) <= 0)
                .Sum(booking => booking.TotalPaymentAmount);
        }

        private (int monthlyBookedAcSeats, int monthlyBookedNonAcSeats) CalculateMonthlyBookedSeats(List<int> scheduleIds)
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfPreviousMonth = new DateTime(today.Year, today.Month, 1).AddMonths(-1);
            DateTime lastDayOfPreviousMonth = firstDayOfPreviousMonth.AddMonths(1).AddDays(-1);

            string startDateString = firstDayOfPreviousMonth.ToString("yyyy-MM-dd");
            string endDateString = lastDayOfPreviousMonth.ToString("yyyy-MM-dd");

            var bookings = _context.TrainBookings
                .Where(booking => scheduleIds.Contains(booking.TrainScheduleId)
                                  && !booking.IsCancelled
                                  && String.Compare(booking.PaymentDate, startDateString) >= 0
                                  && String.Compare(booking.PaymentDate, endDateString) <= 0)
                .ToList();

            int monthlyBookedAcSeats = bookings
                .Where(booking => booking.BookingClass == "1")
                .Sum(booking => int.Parse(booking.BookingSeatCount));

            int monthlyBookedNonAcSeats = bookings
                .Where(booking => booking.BookingClass == "2")
                .Sum(booking => int.Parse(booking.BookingSeatCount));

            return (monthlyBookedAcSeats, monthlyBookedNonAcSeats);
        }

        private (int numberOfRides, int workingDays) CalculateRidesAndWorkingDays(List<int> scheduleIds)
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfPreviousMonth = new DateTime(today.Year, today.Month, 1).AddMonths(-1);
            DateTime lastDayOfPreviousMonth = firstDayOfPreviousMonth.AddMonths(1).AddDays(-1);

            string startDateString = firstDayOfPreviousMonth.ToString("yyyy-MM-dd");
            string endDateString = lastDayOfPreviousMonth.ToString("yyyy-MM-dd");

            var scheduleDates = _context.ScheduledTrainDates
                .Where(schedule => scheduleIds.Contains(schedule.ScheduledTrainSchedulId)
                                   && schedule.IsCompleted
                                   && String.Compare(schedule.DepartureDate, startDateString) >= 0
                                   && String.Compare(schedule.DepartureDate, endDateString) <= 0)
                .ToList();

            int numberOfRides = scheduleDates.Count;
            int workingDays = scheduleDates
                .Select(schedule => DateTime.Parse(schedule.DepartureDate).Date)
                .Distinct()
                .Count();

            return (numberOfRides, workingDays);
        }

        private (int availableAcSeats, int availableNonAcSeats) CalculateAvailableSeats(List<int> scheduleIds)
        {
            var scheduledCarriages = _context.ScheduledCarriages
                .Where(carriage => scheduleIds.Contains(carriage.ScheduledTrainSchedulId))
                .ToList();

            var carriageIds = scheduledCarriages.Select(carriage => carriage.RegisteredCarriageCarriageId).ToList();

            var carriages = _context.RegisteredCarriages
                .Where(carriage => carriageIds.Contains(carriage.CarriageId) && carriage.DeleteState)
                .ToList();

            int availableAcSeats = carriages
                .Where(carriage => carriage.CarriageClass == 1)
                .Sum(carriage => carriage.SeatsCount);

            int availableNonAcSeats = carriages
                .Where(carriage => carriage.CarriageClass == 2)
                .Sum(carriage => carriage.SeatsCount);

            return (availableAcSeats, availableNonAcSeats);
        }
    }
}
