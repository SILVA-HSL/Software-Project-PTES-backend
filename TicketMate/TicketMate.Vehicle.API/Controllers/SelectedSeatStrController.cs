using global::TicketMate.Vehicle.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketMate.Vehicle.API.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectedSeatStrController : ControllerBase
    {
        private readonly ISelSeaStrSer _selSeatStructureService;

        public SelectedSeatStrController(ISelSeaStrSer selSeatStructureService)
        {
            _selSeatStructureService = selSeatStructureService;
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelectedSeatStructure>>> GetSelectedSeatStructures()
        {
            return await _selSeatStructureService.GetSelectedSeatStructures();
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpGet("{id}")]
        public async Task<ActionResult<SelectedSeatStructure>> GetSelectedSeatStructure(int id)
        {
            return await _selSeatStructureService.GetSelectedSeatStructure(id);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpGet("bus/{busId}")]
        public async Task<ActionResult<IEnumerable<SelectedSeatStructure>>> GetSelectedSeatStructuresByBusId(int busId)
        {
            return await _selSeatStructureService.GetSelectedSeatStructuresByBusId(busId);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpPost]
        public async Task<ActionResult<SelectedSeatStructure>> PostSelectedSeatStructure(SelectedSeatStructure seatStructure)
        {
            return await _selSeatStructureService.PostSelectedSeatStructure(seatStructure);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutSelectedSeatStructure(int id, SelectedSeatStructure seatStructure)
        {
            return await _selSeatStructureService.PutSelectedSeatStructure(id, seatStructure);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSelectedSeatStructure(int id)
        {
            return await _selSeatStructureService.DeleteSelectedSeatStructure(id);
        }
    }
}
