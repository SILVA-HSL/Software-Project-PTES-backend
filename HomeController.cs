using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
//using TicketMate.Admin.Domanin;
using TicketMate.Admin.Application.Dtos;
using TicketMate.Admin.Application.Handlers;
using TicketMate.Admin.Api.Models;

namespace TicketMate.Admin.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        /*
        [HttpGet]
        [Route("Users")]
        public async Task<IEnumerable<UserReturn>> GetAllUsers()
        {
            //return (IEnumerable<UserReturn>)await _mediator.Send(new GetUsersQuery { });
        }*/
    }
}
