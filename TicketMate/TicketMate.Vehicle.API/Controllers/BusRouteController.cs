﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Vehicle.Application.Services;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusRouteController : ControllerBase
    {
        private readonly IBusRouteSer _busRouteService;

        public BusRouteController(IBusRouteSer busRouteService)
        {
            _busRouteService = busRouteService;
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusRoute>>> GetBusRoutes()
        {
            return await _busRouteService.GetBusRoutes();
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet("{id}")]
        public async Task<ActionResult<BusRoute>> GetBusRoute(int id)
        {
            return await _busRouteService.GetBusRoute(id);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet("by-routno/{routNo}")]
        public async Task<ActionResult<BusRoute>> GetBusRouteByRoutNo(string routNo)
        {
            return await _busRouteService.GetBusRouteByRoutNo(routNo);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpPost]
        public async Task<ActionResult<BusRoute>> PostBusRoute(BusRoute busRoute)
        {
            return await _busRouteService.PostBusRoute(busRoute);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutBusRoute(int id, BusRoute busRoute)
        {
            return await _busRouteService.PutBusRoute(id, busRoute);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBusRoute(int id)
        {
            return await _busRouteService.DeleteBusRoute(id);
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpDelete("by-routno/{routNo}")]
        public async Task<ActionResult> DeleteBusRouteByRoutNo(string routNo)
        {
            return await _busRouteService.DeleteBusRouteByRoutNo(routNo);
        }
    }
}
