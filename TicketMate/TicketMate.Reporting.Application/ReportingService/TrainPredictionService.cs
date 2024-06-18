using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
    public class TrainPredictionService:ITrainPredictionService
    {
        private readonly IConfiguration _configuration;
        private readonly ReportingDbContext _context;
        private readonly string predictionApiUrl = "http://127.0.0.1:5000/trainpredict";
        private readonly ILogger<BusPredictionService> _logger;
        public TrainPredictionService(ReportingDbContext context, IConfiguration configuration, ILogger<BusPredictionService> logger)
        {
            _configuration = configuration;
            _context = context;
            _logger = logger;
        }

        public async Task<List<TrainPredictionOutputDTO>> GetTrainPredictedIncome(List<TrainPredictionInputDTO> inputDataList)
        {
            List<TrainPredictionOutputDTO> allPredictions = new List<TrainPredictionOutputDTO>();

            foreach (var inputData in inputDataList)
            {
                var inputForModel = new
                {
                    TrainName = inputData.TrainName,
                    AcSeatCount = inputData.AcSeatCount,
                    NonAcSeatCount = inputData.NonAcSeatCount,
                    TicketPrice = inputData.TicketPrice,
                    MonthlyBookedAcSeats = inputData.MonthlyBookedAcSeats,
                    MonthlyBookedNonAcSeats = inputData.MonthlyBookedNonAcSeats,
                    NumberOfRides = inputData.NumberOfRides,
                    WorkingDays = inputData.WorkingDays,
                    PreviousMonthIncome = inputData.PreviousMonthIncome,
                    TrainType = inputData.TrainType,
                    
             
    
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
                        var predictionResult = JsonConvert.DeserializeObject<TrainPredictionResponceDTO>(resultJson);


                        // Log the input and output data for verification
                        Console.WriteLine($"Input: {jsonInputData}");
                        Console.WriteLine($"Output: {resultJson}");
                        var prediction = new TrainPredictionOutputDTO
                        {
                            TrainName = inputData.TrainName,
                            PredictedIncome = predictionResult.TrainPredictedIncomeFormatted,
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

        public async Task StoreTrainPredictionsAsync(List<TrainPredictionOutputDTO> predictions)
        {
            foreach (var prediction in predictions)
            {
                var dailyTrainPrediction = new DailyTrainPrediction
                {
                    TrainName = prediction.TrainName,
                    PredictedIncome = prediction.PredictedIncome,
                    PredictionDate = prediction.PredictionDate
                };

                _context.DailyTrainPredictions.Add(dailyTrainPrediction);
            }

            await _context.SaveChangesAsync();
        }


        public async Task<bool> TrainPredictionsExistForTodayAsync()
        {
            var today = DateTime.Today;
            return await _context.DailyTrainPredictions.AnyAsync(p => p.PredictionDate.Date == today);
        }

    }
}
