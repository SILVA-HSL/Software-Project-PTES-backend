using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TicketMate.Reporting.Application.ReportingService;
using TicketMate.Reporting.Domain.Dtos;

namespace TicketMate.Reporting.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusPredictionController : ControllerBase
    {
        private readonly IBusPredictionDataService _busPredictionDataService;
        private readonly IBusPredictionService _busPredictionService;
        private readonly IPredictionCacheService _predictionCacheService;


        public BusPredictionController(IBusPredictionDataService predictionDataService, IBusPredictionService predictionService,IPredictionCacheService predictionCacheService)
        {
            _busPredictionDataService = predictionDataService;
            _busPredictionService = predictionService;
            _predictionCacheService = predictionCacheService;

        }
        [HttpGet("predict")]
        public async Task<IActionResult> GetPredictedIncome()
        {
            try
            {

                // Check if the cache is valid
                if (_predictionCacheService.IsCacheValid())
                {
                    // Return cached predictions if cache is valid
                    var cachedPredictions = await _predictionCacheService.GetPredictionsAsync();
                    return Ok(cachedPredictions);
                }
                // Get all prediction input data from the PredictionDataService
                var predictionInputData = _busPredictionDataService.GetPredictionDataForAllBuses();

                // Get predicted income data from the PredictionService
                var predictedData = await _busPredictionService.GetPredictedIncome(predictionInputData);

                // Update cache with the new predictions
                await _predictionCacheService.SetPredictionsAsync(predictedData);

                return Ok(predictedData);
            }
            catch (Exception ex)
            {
                // Log exception and return an error response
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        //[HttpGet("predict-all")]
        //public async Task<IActionResult> PredictForAllBuses()
        //{
        //    try
        //    {
        //        // Get prediction data for all buses
        //        var predictionDataList = _predictionDataService.GetPredictionDataForAllBuses();

        //        var allPredictions = new List<PredictionOutputDTO>();

        //        // Iterate over each PredictionInputDTO and get predictions
        //        foreach (var predictionData in predictionDataList)
        //        {
        //            var predictions = await _predictionService.GetPredictedIncome(predictionData);
        //            allPredictions.AddRange(predictions);
        //        }

        //        return Ok(allPredictions);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log exception and return an error response
        //        // Assuming you have some logging mechanism in place
        //        return StatusCode(500, "Internal server error");
        //    }
        //}
    }
}

