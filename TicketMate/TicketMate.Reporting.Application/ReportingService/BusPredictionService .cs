using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using TicketMate.Reporting.Infrastructure;
using TicketMate.Reporting.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketMate.Reporting.Domain.Models;

namespace TicketMate.Reporting.Application.ReportingService
{
    public class BusPredictionService : IBusPredictionService
    {

        private readonly IConfiguration _configuration;
        private readonly ReportingDbContext _context;
        private readonly string predictionApiUrl = "http://127.0.0.1:5000/predict";
        private readonly ILogger<BusPredictionService> _logger;



        public BusPredictionService(ReportingDbContext context, IConfiguration configuration, ILogger<BusPredictionService> logger)
        {
            _configuration = configuration;
            _context = context;
            _logger = logger;
        }

        public async Task<List<BusPredictionOutputDTO>> GetPredictedIncome(List<BusPredictionInputDTO> inputDataList)
        {
            List<BusPredictionOutputDTO> allPredictions = new List<BusPredictionOutputDTO>();

            foreach (var inputData in inputDataList)
            {
                var inputForModel = new
                {
                    SeatCount = inputData.SeatCount,
                    ACNonAC = inputData.ACNonAC,
                    TicketPrice = inputData.TicketPrice,
                    MonthlyBookedSeats = inputData.MonthlyBookedSeats,
                    NumberOfRides = inputData.NumberOfRides,
                    WorkingDays = inputData.WorkingDays,
                    PreviousMonthIncome = inputData.PreviousMonthIncome,
                    BaseMonthlyIncome = inputData.BaseMonthlyIncome,
                    Ac = inputData.AC,
                    SemiLux = inputData.SemiLux,
                    Normal = inputData.Normal,
                    Luxury = inputData.Luxury,

                };

                var jsonInputData = JsonConvert.SerializeObject(inputForModel);
                var content = new StringContent(jsonInputData, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    try
                    {
                        var response = await client.PostAsync(predictionApiUrl, content);
                        response.EnsureSuccessStatusCode();

                        var resultJson = await response.Content.ReadAsStringAsync();
                        var predictionResult = JsonConvert.DeserializeObject<PredictionResponseDTO>(resultJson);

                        Console.WriteLine($"Input: {jsonInputData}");
                        Console.WriteLine($"Output: {resultJson}");
                        var prediction = new BusPredictionOutputDTO
                        {
                            BusNo = inputData.BusNo,
                            BusId = inputData.BusId,
                            UserId = inputData.UserId,
                            PredictedIncome = predictionResult.PredictedIncomeFormatted,
                            PredictionDate = DateTime.Now
                        };


                        allPredictions.Add(prediction);
                    }
                    catch (HttpRequestException httpEx)
                    {
                        _logger.LogError(httpEx, "An HTTP error occurred while calling the prediction API.");
                        throw;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred while calling the prediction API.");
                        throw;
                    }
                }
            }

            return allPredictions;
        }


        public async Task StorePredictionsAsync(List<BusPredictionOutputDTO> predictions)
        {
            foreach (var prediction in predictions)
            {
                var dailyBusPrediction = new DailyBusPrediction
                {
                    BusNo = prediction.BusNo,
                    UserId = prediction.UserId,
                    BusId = prediction.BusId,
                    PredictedIncome = prediction.PredictedIncome,
                    PredictionDate = prediction.PredictionDate
                };

                _context.DailyBusPredictions.Add(dailyBusPrediction);
            }

            await _context.SaveChangesAsync();
        }


        public async Task<bool> PredictionsExistForTodayAsync()
        {
            var today = DateTime.Today;
            return await _context.DailyBusPredictions.AnyAsync(p => p.PredictionDate.Date == today);
        }



    }
}