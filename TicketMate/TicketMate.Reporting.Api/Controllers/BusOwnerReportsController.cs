using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Reporting.Application.ReportingService;

namespace TicketMate.Reporting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusOwnerReportsController : ControllerBase
    {
   
       
            private readonly IBusOwnerReportingService _busOwnerReportingService;

            public BusOwnerReportsController(IBusOwnerReportingService busOwnerReportingService)
            {
            _busOwnerReportingService = busOwnerReportingService;
            }

        [HttpGet("GetOwnerReport/{userId}")]
        public async Task<IActionResult> GetOwnerReport(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID cannot be null or empty.");
            }

            var report = await _busOwnerReportingService.GetOwnerReportAsync(userId);

            if (report == null || !report.Any())
            {
                return NotFound("No report found for the provided user ID.");
            }

            return Ok(report);
        }

        [HttpGet("GetMonthlyOwnerReport/{userId}")]
        public async Task<IActionResult> GetMonthlyOwnerReport(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID cannot be null or empty.");
            }

            var report = await _busOwnerReportingService.GetMonthlyOwnerReportAsync(userId);

            if (report == null || !report.Any())
            {
                return NotFound("No report found for the provided user ID.");
            }

            return Ok(report);
        }

        [HttpGet("GetQuarterlyOwnerReport/{userId}")]
        public async Task<IActionResult> GetQuarterlyOwnerReport(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID cannot be null or empty.");
            }

            var report = await _busOwnerReportingService.GetQuarterlyOwnerReportAsync(userId);

            if (report == null || !report.Any())
            {
                return NotFound("No report found for the provided user ID.");
            }

            return Ok(report);
        }

        [HttpGet("GetYearlyOwnerReport/{userId}")]
        public async Task<IActionResult> GetYearlyOwnerReport(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID cannot be null or empty.");
            }

            var report = await _busOwnerReportingService.GetYearlyOwnerReportAsync(userId);

            if (report == null || !report.Any())
            {
                return NotFound("No report found for the provided user ID.");
            }

            return Ok(report);
        }
    }
}
