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


        [HttpGet("daily/{userId}")]
        public IActionResult GetDailyStatistics(string userId)
        {
            var today = DateTime.Today;
            var stats = _adminReportingService.GetStatistics(userId, today, today);
            return Ok(stats);
        }

        [HttpGet("monthly/{userId}")]
        public IActionResult GetMonthlyStatistics(string userId)
        {
            var startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            var stats = _adminReportingService.GetStatistics(userId, startDate, endDate);
            return Ok(stats);
        }

        [HttpGet("3months/{userId}")]
        public IActionResult GetThreeMonthsStatistics(string userId)
        {
            var endDate = DateTime.Today;
            var startDate = endDate.AddMonths(-3);
            var stats = _adminReportingService.GetStatistics(userId, startDate, endDate);
            return Ok(stats);
        }

        [HttpGet("yearly/{userId}")]
        public IActionResult GetYearlyStatistics(string userId)
        {
            var startDate = new DateTime(DateTime.Today.Year, 1, 1);
            var endDate = new DateTime(DateTime.Today.Year, 12, 31);
            var stats = _adminReportingService.GetStatistics(userId, startDate, endDate);
            return Ok(stats);
        }


        [HttpGet("total-predicted-income/{userId}")]
        public IActionResult TotalPredictedIncomeForUser(string userId)
        {
            try
            {
                var result = _adminReportingService.GetTotalPredictedIncomeForUser(userId);

                // Check if the result indicates that the user does not exist
                if (result.StartsWith("User with ID"))
                {
                    return NotFound(result); // Return 404 status code with the message
                }
                return Ok(decimal.Parse(result));

             
            }
            catch (Exception ex)
            {
                // Log exception and return an error response
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}



