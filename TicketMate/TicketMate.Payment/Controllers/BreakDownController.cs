using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TicketMate.Payment.Infrastructure;

namespace TicketMate.Payment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreakdownController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public BreakdownController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBreakdown([FromBody] BreakdownUpdate update)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", update.Message);
            return Ok();
        }
    }

    public class BreakdownUpdate
    {
        public string Message { get; set; }
    }
}
