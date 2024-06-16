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

namespace TicketMate.Reporting.Application.ReportingService
{
    public class BusPredictionService : IBusPredictionService
    {

        private readonly IConfiguration _configuration;
        private readonly ReportingDbContext _context;
        private readonly string predictionApiUrl = "http://127.0.0.1:5000/predict";
        private readonly IPredictionCacheService _cacheService;


        public BusPredictionService(IConfiguration configuration, ReportingDbContext context,IPredictionCacheService cacheService)
        {
            _configuration = configuration;
            _context = context;
            _cacheService = cacheService;
        }

        public async Task<List<BusPredictionOutputDTO>> GetPredictedIncome(List<BusPredictionInputDTO> inputDataList)
        {
            if (_cacheService.IsCacheValid())
            {
                return await _cacheService.GetPredictionsAsync();
            }

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
                    Luxury = inputData.Luxury
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
                        var prediction = JsonConvert.DeserializeObject<BusPredictionOutputDTO>(resultJson);

                        // Log the input and output data for verification
                        Console.WriteLine($"Input: {jsonInputData}");
                        Console.WriteLine($"Output: {resultJson}");

                        prediction.BusNo = inputData.BusNo; // Ensure the bus number is included
                        prediction.PredictionDate = DateTime.Now; // Store the time the prediction happened
                        allPredictions.Add(prediction);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while calling the prediction API: {ex.Message}");
                    }
                }
            }
            await _cacheService.SetPredictionsAsync(allPredictions);

            return allPredictions;
        }
        //public async Task<List<PredictionOutputDTO>> GetPredictedIncome(PredictionInputDTO inputData)
        //{
        //    // Prepare input data for the prediction model
        //    var inputForModel = new
        //    {
        //        SeatCount = inputData.SeatCount,
        //        ACNonAC = inputData.ACNonAC,
        //        TicketPrice = inputData.TicketPrice,
        //        MonthlyBookedSeats = inputData.MonthlyBookedSeats,
        //        NumberOfRides = inputData.NumberOfRides,
        //        WorkingDays = inputData.WorkingDays,
        //        PreviousMonthIncome = inputData.PreviousMonthIncome,
        //        BaseMonthlyIncome = inputData.BaseMonthlyIncome,
        //        Ac = inputData.AC,
        //        SemiLux = inputData.SemiLux,
        //        Normal = inputData.Normal,
        //        Luxury = inputData.Luxury
        //        // Add other properties needed by the prediction model
        //    };

        //    // Serialize inputForModel to JSON
        //    var jsonInputData = JsonConvert.SerializeObject(inputForModel);
        //    var content = new StringContent(jsonInputData, Encoding.UTF8, "application/json");

        //    using (var client = new HttpClient())
        //    {
        //        var response = await client.PostAsync(_configuration["http://127.0.0.1:5000/predict"], content);
        //        response.EnsureSuccessStatusCode();

        //        var resultJson = await response.Content.ReadAsStringAsync();
        //        var predictions = JsonConvert.DeserializeObject<List<PredictionOutputDTO>>(resultJson);

        //        // Store predictions in the database if needed
        //        StorePredictions(predictions, inputData.BusNo);

        //        return predictions;
        //    }
        //}

        //public void StorePredictions(List<PredictionOutputDTO> predictions, string busNo)
        //{
        //    var connectionString = _configuration.GetConnectionString("Server=tcp:ptesserver.database.windows.net,1433;Initial Catalog=ptescentral;Persist Security Info=False;User ID=AdminPTES;Password=PTES@admin;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        foreach (var prediction in predictions)
        //        {
        //            var query = "INSERT INTO PredictedIncome (BusId, PredictedIncome, PredictionDate) VALUES (@BusId, @PredictedIncome, @PredictionDate)";

        //            using (var command = new SqlCommand(query, connection))
        //            {
        //                command.Parameters.AddWithValue("@BusId", busNo); // Use BusId or another identifier
        //                command.Parameters.AddWithValue("@PredictedIncome", prediction.PredictedIncome);
        //                command.Parameters.AddWithValue("@PredictionDate", DateTime.Now);

        //                command.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //}

        //public async Task<List<PredictionOutputDTO>> FetchPredictedDataFromDatabase()
        //{
        //    var connectionString = _configuration.GetConnectionString("Server=tcp:ptesserver.database.windows.net,1433;Initial Catalog=ptescentral;Persist Security Info=False;User ID=AdminPTES;Password=PTES@admin;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        await connection.OpenAsync();

        //        var query = "SELECT BusNumber, PredictedIncome, PredictionDate FROM PredictedIncome";
        //        using (var command = new SqlCommand(query, connection))
        //        {
        //            var predictedData = new List<PredictionOutputDTO>();
        //            using (var reader = await command.ExecuteReaderAsync())
        //            {
        //                while (await reader.ReadAsync())
        //                {
        //                    var busNumber = reader.GetString(0);
        //                    var predictedIncome = reader.GetDecimal(1);
        //                    var predictionDate = reader.GetDateTime(2);

        //                    var predictedDto = new PredictionOutputDTO
        //                    {
        //                        BusNo = busNumber,
        //                        PredictedIncome = predictedIncome,
        //                        PredictionDate = predictionDate
        //                    };

        //                    predictedData.Add(predictedDto);
        //                }
        //            }

        //            return predictedData;
        //        }
        //    }
        //}
    }
}