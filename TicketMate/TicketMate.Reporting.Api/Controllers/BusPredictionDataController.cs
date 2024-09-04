using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TicketMate.Reporting.Application.ReportingService;
using TicketMate.Reporting.Domain.Dtos;

namespace TicketMate.Reporting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusPredictionDataController : ControllerBase
    {
        private readonly IBusPredictionDataService _busPredictionDataService;

        public BusPredictionDataController(IBusPredictionDataService predictionDataService)
        {
            _busPredictionDataService = predictionDataService;
        }

        [HttpGet("prediction-data")]
        public ActionResult<List<BusPredictionInputDTO>> GetPredictionDataForAllBuses()
        {
            var predictionData = _busPredictionDataService.GetPredictionDataForAllBuses();
            return Ok(predictionData);
        }
    }
}
