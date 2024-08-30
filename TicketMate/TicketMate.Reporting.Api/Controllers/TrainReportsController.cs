using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Reporting.Application.ReportingService;
using TicketMate.Reporting.Domain.Dtos;
using static TicketMate.Reporting.Application.ReportingService.TrainReportingService;

namespace TicketMate.Reporting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainReportsController : ControllerBase
    {
        private readonly ITrainReportingService _trainReportService;

        public TrainReportsController(ITrainReportingService trainReportingService)
        {
            _trainReportService = trainReportingService;
        }

        [HttpGet("{userId}/{filter}")]
        public async Task<ActionResult<List<TrainReportDTO>>> GetTrainReport(string userId, DateFilter filter)
        {
            await _trainReportService.EnsurePredictionsExistForTodayAsync();

            var report = await _trainReportService.GenerateTrainReportAsync(userId, filter);
            return Ok(report);
        }

        //[HttpGet("TrainOwners")]
        //public IActionResult GetTrainOwnerUserIds()
        //{
        //    var userIds = _trainReportService.GetTrainOwnerUserIds();
        //    return Ok(userIds);
        //}

    }
}
