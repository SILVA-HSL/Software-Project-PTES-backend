using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Reporting.Application.ReportingService;
using TicketMate.Reporting.Domain.Models;
using TicketMate.Reporting.Infrastructure;

namespace TicketMate.Reporting.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminReportController : ControllerBase
    {
        private readonly IAdminReportingService _adminReportingService;


        public AdminReportController(IAdminReportingService reportingService)
        {
            _adminReportingService = reportingService;
        }

        [HttpGet("busowners")]
        public IActionResult GetBusOwnerUserIds()
        {


            var userIds = _adminReportingService.GetBusOwnerUserIds();
            return Ok(userIds);
        }

        [HttpGet("trainOwners")]
        public IActionResult GetTrainOwnerUserIds()
        {


            var userIds = _adminReportingService.GetTrainOwnerUserIds();
            return Ok(userIds);
        }


        [HttpGet("daily/{userId}")]
        public async Task<IActionResult> GetDailyStatistics(string userId)
        {
            await _adminReportingService.EnsurePredictionsAreAvailableAsync();

            var today = DateTime.Today;
            var stats = _adminReportingService.GetStatistics(userId, today, today);
            return Ok(stats);
        }

        [HttpGet("monthly/{userId}")]
        public async Task<IActionResult> GetMonthlyStatistics(string userId)
        {
            await _adminReportingService.EnsurePredictionsAreAvailableAsync();
            // Determine the start and end dates for the previous month

            var startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            var stats = _adminReportingService.GetStatistics(userId, startDate, endDate);
            return Ok(stats);
        }

        [HttpGet("3months/{userId}")]
        public async Task<IActionResult> GetThreeMonthsStatistics(string userId)
        {
            await _adminReportingService.EnsurePredictionsAreAvailableAsync();


            var endDate = DateTime.Today;
            var startDate = endDate.AddMonths(-3);
            var stats = _adminReportingService.GetStatistics(userId, startDate, endDate);
            return Ok(stats);
        }

        [HttpGet("yearly/{userId}")]
        public async Task<IActionResult> GetYearlyStatistics(string userId)
        {
            await _adminReportingService.EnsurePredictionsAreAvailableAsync();


            var startDate = new DateTime(DateTime.Today.Year, 1, 1);
            var endDate = new DateTime(DateTime.Today.Year, 12, 31);
            var stats = _adminReportingService.GetStatistics(userId, startDate, endDate);
            return Ok(stats);
        }


        [HttpGet("total-predicted-income/{userId}")]
        public async Task<IActionResult> TotalPredictedIncomeForUser(string userId)
        {
            try
            {
                var result = await _adminReportingService.GetTotalPredictedIncomeForUserAsync(userId);

                if (result.StartsWith("User with ID"))
                {
                    return NotFound(result);
                }
                return Ok(decimal.Parse(result));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


    }
}



