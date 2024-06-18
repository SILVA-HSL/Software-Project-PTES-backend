using Microsoft.AspNetCore.Mvc;
using TicketMate.Payment.Application.DriverService;

namespace TicketMate.Payment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverBreakdownController : ControllerBase
    {
        private readonly IDriverBreakdownService _driverBreakdownService;

        public DriverBreakdownController(IDriverBreakdownService driverBreakdownService)
        {
            _driverBreakdownService = driverBreakdownService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DriverBreakdownRequest request)
        {
            if (ModelState.IsValid)
            {
                var breakdown = await _driverBreakdownService.CreateDriverBreakdownAsync(request.DriverId,request.BusNo);
                return Ok(breakdown);
            }

            return BadRequest(ModelState);
        }
    }

    public class DriverBreakdownRequest
    {
        public int DriverId { get; set; }
        public string BusNo { get; set; }
    }
}
