using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Reporting.Application.ReportingService;

namespace TicketMate.Reporting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainPredictionController : ControllerBase
    {
        private readonly ITrainPredictionDataService _trainPredictionDataService;
        private readonly ITrainPredictionService _trainPredictionService;
        private readonly ILogger<TrainPredictionController> _logger;


        public TrainPredictionController(ITrainPredictionDataService trainpredictionDataService, ITrainPredictionService trainPredictionService, ILogger<TrainPredictionController> logger)//,IPredictionCacheService predictionCacheService
        {
            _trainPredictionDataService = trainpredictionDataService;
            _logger = logger;
            _trainPredictionService = trainPredictionService;

        }
        [HttpGet("predict")]
        public async Task<IActionResult> GetPredictedIncome()
        {

            try
            {
                _logger.LogInformation("GetPredictedIncome called.");

                //Check if predictions for today already exist
                if (await _trainPredictionService.TrainPredictionsExistForTodayAsync())
                {
                    _logger.LogInformation("Predictions for today already exist. Skipping prediction generation.");
                    return Ok("Predictions for today already exist.");
                } // Log the input and output data for verification


                _logger.LogInformation("GetPredictedIncome called.");

                var predictionInputData = _trainPredictionDataService.GetPredictionDataForAllTrains();

                var predictedData = await _trainPredictionService.GetTrainPredictedIncome(predictionInputData);

                _logger.LogInformation("Storing predictions in database.");
                await _trainPredictionService.StoreTrainPredictionsAsync(predictedData);
                return Ok(predictedData);
            }
            catch (Exception ex)
            {

                // Console.WriteLine($"An error occurred: {ex.Message}");

                _logger.LogError(ex, "An error occurred while getting predicted income.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
