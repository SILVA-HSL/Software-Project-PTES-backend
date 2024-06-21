using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Admin.Application.Services;

namespace TicketMate.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapConnectionController : ControllerBase
    {

        private readonly IMapConnections _mapConnections;

        public MapConnectionController(IMapConnections mapConnections)
        {
            _mapConnections = mapConnections;
        }

        [HttpGet("getBusScheduleId/{Id}")]
    public IActionResult getBusScheduleId(int Id)
    {
            try { 
            var busScheduleId = _mapConnections.getBusScheduleId(Id);
            return Ok(busScheduleId);
                }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getTrainScheduleId/{Id}")]
        public IActionResult getTrainScheduleId(int Id)
        {
            try
            {
                var trainScheduleId = _mapConnections.getTrainScheduleid(Id);
                return Ok(trainScheduleId);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }       

    }
}
