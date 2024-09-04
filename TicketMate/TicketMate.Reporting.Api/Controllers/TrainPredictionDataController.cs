using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Reporting.Application.ReportingService;
using TicketMate.Reporting.Domain.Dtos;

namespace TicketMate.Reporting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainPredictionDataController : ControllerBase
    {
        private readonly ITrainPredictionDataService _trainPredictionDataService;
        public TrainPredictionDataController(ITrainPredictionDataService trainPredictionDataService)
        {
            _trainPredictionDataService = trainPredictionDataService;
        }


        [HttpGet("GetPredictionDataForAllTrains")]
        public ActionResult<List<TrainPredictionInputDTO>> GetPredictionDataForAllTrains()
        {
            var predictionDataList = _trainPredictionDataService.GetPredictionDataForAllTrains();
            return Ok(predictionDataList);
        }
    }
}
