using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TicketMate.Reporting.Domain.Dtos;
using TicketMate.Reporting.Infrastructure;

namespace TicketMate.Reporting.Application.ReportingService
{
    public class BusPredictionDataService : IBusPredictionDataService

    {
        private readonly ReportingDbContext _context;

        public BusPredictionDataService(DbContextOptions<ReportingDbContext> dbContextOptions)
        {
            _context = new ReportingDbContext(dbContextOptions);
        }


        public List<BusPredictionInputDTO> GetPredictionDataForAllBuses()
        {
            List<BusPredictionInputDTO> predictionDataList = new List<BusPredictionInputDTO>();

            // Get all registered buses
            var registeredBuses = _context.RegisteredBuses
                .Where(b => b.DeleteState == true) // Consider only buses that are not deleted
                .ToList();

            foreach (var bus in registeredBuses)
            {
                // Initialize PredictionInputDTO for each bus
                var predictionInput = new BusPredictionInputDTO
                {
                    BusNo = bus.BusNo,
                    BusId = bus.BusId,
                    UserId = bus.UserId,
                    SeatCount = bus.SetsCount,
                    ACNonAC = bus.ACorNONAC ? 1 : 0, // Convert bool to int
                    TicketPrice = 0, // Initialize to 0 initially
                    MonthlyBookedSeats = 0,
                    NumberOfRides = 0,
                    WorkingDays = 0,
                    PreviousMonthIncome = 0,
                    BaseMonthlyIncome = 0,
                    AC = 0,
                    SemiLux = 0,
                    Normal = 0,
                    Luxury = 0
                };

                // Fetch ticket price from the first schedule (assuming same ticket price for all schedules of a bus)
                var firstSchedule = _context.ScheduledBuses
                    .FirstOrDefault(s => s.BusNo == bus.BusNo && s.DeleteState == true);

                if (firstSchedule != null)
                {
                    predictionInput.TicketPrice = (double)firstSchedule.TicketPrice;
                }

                // Fetch additional data from ScheduledBus table for this bus
                var schedulesForBus = _context.ScheduledBuses
                    .Where(s => s.BusNo == bus.BusNo && s.DeleteState == true) // Consider schedules for this bus and not deleted
                    .ToList();

                // Aggregate data from schedules
                foreach (var schedule in schedulesForBus)
                {
                    // Aggregate based on comfortability
                    switch (schedule.Comfortability.ToLower())
                    {
                        case "normal":
                            predictionInput.Normal++;
                            break;
                        case "semi-lux":
                            predictionInput.SemiLux++;
                            break;
                        case "ac":
                            predictionInput.AC++;
                            break;
                        case "lux":
                            predictionInput.Luxury++;
                            break;
                        default:
                            // Handle unexpected comfortability values
                            break;
                    }

                    // Optionally, aggregate other fields like MonthlyBookedSeats, NumberOfRides, etc.
                }
                // Calculate previous month's monthly booked seats and income
                CalculatePreviousMonthData(predictionInput, bus.BusId);

                // Add calculated PredictionInputDTO to list
                predictionDataList.Add(predictionInput);
            }

            return predictionDataList;
        }


        public void CalculatePreviousMonthData(BusPredictionInputDTO predictionInput, int busId)
        {
            // Determine the start and end dates for the previous month
            //var today = DateTime.Today;
            //var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            //var lastDayOfPreviousMonth = firstDayOfMonth.AddDays(-1);
            //var firstDayOfPreviousMonth = new DateTime(lastDayOfPreviousMonth.Year, lastDayOfPreviousMonth.Month, 1);

            //string startDateString = firstDayOfPreviousMonth.ToString("yyyy-MM-dd");
            //string endDateString = lastDayOfPreviousMonth.ToString("yyyy-MM-dd");

            var endDate = DateTime.Today;
            var startDate = endDate.AddDays(-30);

            string startDateString = startDate.ToString("yyyy-MM-dd");
            string endDateString = endDate.ToString("yyyy-MM-dd");

            // Fetch bookings for the bus in the previous month
            var bookings = _context.BusBookings
                .Where(b => b.BusId == busId &&
                            String.Compare(b.PaymentDate, startDateString) >= 0 &&
                            String.Compare(b.PaymentDate, endDateString) <= 0 &&
                            !b.IsCancelled) // Filter out cancelled bookings
                .ToList();

            // Calculate monthly booked seats and income
            foreach (var booking in bookings)
            {
                // Add booked seats for the month
                predictionInput.MonthlyBookedSeats += Convert.ToInt32(booking.BookingSeatCount);

                // Add total payment amount for the month
                predictionInput.PreviousMonthIncome += Convert.ToDouble(booking.TotalPaymentAmount);
            }

            // Initialize BaseMonthlyIncome
            predictionInput.BaseMonthlyIncome = predictionInput.TicketPrice * predictionInput.MonthlyBookedSeats;



            // Fetch all scheduled bus IDs for the given bus number (BusNo)
            var scheduledBusIds = _context.ScheduledBuses
                .Where(sb => sb.BusNo == predictionInput.BusNo && sb.DeleteState)
                .Select(sb => sb.ScheduleId)
                .ToList();


            // Fetch all scheduled bus dates for the retrieved scheduled bus IDs
            var scheduledBusDates = _context.ScheduledBusDate
        .Where(sbd => scheduledBusIds.Contains(sbd.ScheduledBusScheduleId) &&
                      String.Compare(sbd.DepartureDate, startDateString) >= 0 &&
                      String.Compare(sbd.DepartureDate, endDateString) <= 0 &&
                      sbd.IsCompleted)
        .ToList();

            // Calculate number of rides
            predictionInput.NumberOfRides = scheduledBusDates.Count;
        }


    }
}
