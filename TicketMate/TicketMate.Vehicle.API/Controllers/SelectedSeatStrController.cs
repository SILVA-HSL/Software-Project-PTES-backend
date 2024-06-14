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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelectedSeatStructure>>> GetSelectedSeatStructures()
        {
            return await _selSeatStructureService.GetSelectedSeatStructures();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SelectedSeatStructure>> GetSelectedSeatStructure(int id)
        {
            return await _selSeatStructureService.GetSelectedSeatStructure(id);
        }

        [HttpGet("bus/{busId}")]
        public async Task<ActionResult<IEnumerable<SelectedSeatStructure>>> GetSelectedSeatStructuresByBusId(int busId)
        {
            return await _selSeatStructureService.GetSelectedSeatStructuresByBusId(busId);
        }

        [HttpPost]
        public async Task<ActionResult<SelectedSeatStructure>> PostSelectedSeatStructure(SelectedSeatStructure seatStructure)
        {
            return await _selSeatStructureService.PostSelectedSeatStructure(seatStructure);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSelectedSeatStructure(int id, SelectedSeatStructure seatStructure)
        {
            return await _selSeatStructureService.PutSelectedSeatStructure(id, seatStructure);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSelectedSeatStructure(int id)
        {
            return await _selSeatStructureService.DeleteSelectedSeatStructure(id);
        }
    }
}
