using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TicketMate.Reporting.Application.ReportingService;
using TicketMate.Reporting.Domain.Dtos;
using TicketMate.Reporting.Infrastructure;

namespace TicketMate.Reporting.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusPredictionController : ControllerBase
    {
        private readonly IBusPredictionDataService _busPredictionDataService;
        private readonly IBusPredictionService _busPredictionService;
        private readonly ILogger<BusPredictionController> _logger;




        public BusPredictionController(IBusPredictionDataService predictionDataService, IBusPredictionService busPredictionService, ILogger<BusPredictionController> logger )//,IPredictionCacheService predictionCacheService
        {
            _busPredictionDataService = predictionDataService;
            _logger = logger;
            _busPredictionService = busPredictionService;

        }
        [HttpGet("predict")]
        public async Task<IActionResult> GetPredictedIncome()
        {

            try
            {
                _logger.LogInformation("GetPredictedIncome called.");

                //Check if predictions for today already exist
                if (await _busPredictionService.PredictionsExistForTodayAsync())
                {
                    _logger.LogInformation("Predictions for today already exist. Skipping prediction generation.");
                    return Ok("Predictions for today already exist.");
                }

                _logger.LogInformation("GetPredictedIncome called.");
               
                var predictionInputData = _busPredictionDataService.GetPredictionDataForAllBuses();

                var predictedData = await _busPredictionService.GetPredictedIncome(predictionInputData);

                _logger.LogInformation("Storing predictions in database.");
                await _busPredictionService.StorePredictionsAsync(predictedData);
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

