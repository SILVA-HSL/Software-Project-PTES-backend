using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Reporting.Application.ReportingService;
using TicketMate.Reporting.Domain.Models;
using TicketMate.Reporting.Infrastructure;

namespace TicketMate.Reporting.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly IReportingService _reportingService;

        public TodosController(IReportingService reportingService)
        {
            _reportingService = reportingService;
        }

        [HttpGet]
        public ActionResult<List<Todo>> GetTodos()
        {
            var todos = _reportingService.GetTodos();
            return Ok(todos);
        }
    }
}



