/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TicketMate.Admin.Application.Services;
using TicketMate.Admin.Domain.Models;
using System.Threading.Tasks;
using TicketMate.Admin.Infastructure;

namespace TicketMate.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationHub _locationService;
        private readonly LocationContext _context;

        public LocationController(ILocationHub locationService)
        {
            _locationService = locationService;
        }

        public async Task<IActionResult> UpdateLocation([FromBody] LocationUpdateModel model)
        {
            await _context.Clients.Group(model.RideId.ToString()).SendAsync("ReceiveLocation", model.Latitude, model.Longitude);
            return Ok();
        }

    }


    */




using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TicketMate.Admin.Application.Services;
using TicketMate.Admin.Domain.Models;
using System.Threading.Tasks;
using TicketMate.Admin.Infastructure;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace TicketMate.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        /*  private readonly IHubContext<LocationHub> _locationHubContext;
           private readonly LocationHub _context;

           public LocationController(IHubContext<LocationHub> locationHubContext, LocationHub context)
           {
               _locationHubContext = locationHubContext;
               _context = context;
           }
          */

        private readonly IHubContext<LocationHub> _locationHubContext;

        public LocationController(IHubContext<LocationHub> locationHubContext)
        {
            _locationHubContext = locationHubContext;
            

        }


        [HttpPost("UpdateLocation")]
        public async Task<IActionResult> UpdateLocation([FromBody] LocationUpdateModel model)
        {
            try
            {
                await _locationHubContext.Clients.Group(model.RideId.ToString()).SendAsync("ReceiveLocation", model.Latitude, model.Longitude);
               // _context.SendLocation(model.RideId, model.Latitude, model.Longitude);
               // _locationHubContext.JoinRideGroup(model.RideId);
            }
            catch(Exception e)
            {
                return BadRequest("error in backend api"+e.Message);
            }
            return Ok();
        }
        /*

                [HttpPost("StartRide/{rideId}")]
                public async Task<IActionResult> StartRide(int rideId)
                {
                    await _locationHubContext.JoinRideGroup(rideId);
                   // await _locationHubContext.JoinRideGroup(rideId);

                    return Ok();
                }

                [HttpPost("EndRide/{rideId}")]
                public async Task<IActionResult> EndRide(int rideId)
                {
                    //await _context.Clients.All.LeaveRideGroup(rideId);
                    await _context.LeaveRideGroup(rideId);

                    return Ok();
                }

                */
        ///[Authorize(Roles = "DRIVER")]
        [HttpPost("StartRide/{rideId}")]
        public async Task<IActionResult> StartRide(int rideId, [FromBody] ConnectionPayload payload)
        {
            try
            {
              //  Console.WriteLine($"Received payload: {payload}"
                string connectionId = payload.ConnectionId;
                if (string.IsNullOrEmpty(connectionId))
                {
                    return BadRequest("ConnectionId is missing or empty.");
                }
                await _locationHubContext.Groups.AddToGroupAsync(connectionId, rideId.ToString());
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Error in backend API: " + e.Message);
            }
        }
        //[Authorize(Roles = "DRIVER")]
        [HttpPost("EndRide/{rideId}")]
        public async Task<IActionResult> EndRide(int rideId)
        {
            try
            {
                //string connectionId = payload.connectionId;

                // await _locationHubContext.Groups.RemoveFromGroupAsync(connectionId, rideId.ToString());
                await _locationHubContext.Clients.Group(rideId.ToString()).SendAsync("EndRide", rideId);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Error in backend API: " + e.Message);
            }
        }
    }


    public class ConnectionPayload
    {
        public string ConnectionId { get; set; }
    }
}


