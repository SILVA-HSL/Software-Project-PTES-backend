using Microsoft.AspNetCore.Mvc;
using TicketMate.Vehicle.Application.Services;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelCarriageSeatStruController : ControllerBase
    {
        private readonly ISelCarriageSeatStructureSer _selCarriageSeatStructureService;

        public SelCarriageSeatStruController(ISelCarriageSeatStructureSer selCarriageSeatStructureService)
        {
            _selCarriageSeatStructureService = selCarriageSeatStructureService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelCarriageSeatStructure>>> GetSelCarriageSeatStructures()
        {
            return await _selCarriageSeatStructureService.GetSelCarriageSeatStructures();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SelCarriageSeatStructure>> GetSelCarriageSeatStructure(int id)
        {
            return await _selCarriageSeatStructureService.GetSelCarriageSeatStructure(id);
        }

        [HttpGet("ByCarriageId/{carriageId}")]
        public async Task<ActionResult<IEnumerable<SelCarriageSeatStructure>>> GetSelCarriageSeatStructuresByCarriageId(int carriageId)
        {
            return await _selCarriageSeatStructureService.GetSelCarriageSeatStructuresByCarriageId(carriageId);
        }

        [HttpDelete("ByCarriageId/{carriageId}")]
        public async Task<ActionResult> DeleteSelCarriageSeatStructureByCarriageId(int carriageId)
        {
            return await _selCarriageSeatStructureService.DeleteSelCarriageSeatStructureByCarriageId(carriageId);
        }

        [HttpPost]
        public async Task<ActionResult<SelCarriageSeatStructure>> PostSelCarriageSeatStructure(SelCarriageSeatStructure selCarriageSeatStructure)
        {
            return await _selCarriageSeatStructureService.PostSelCarriageSeatStructure(selCarriageSeatStructure);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSelCarriageSeatStructure(int id, SelCarriageSeatStructure selCarriageSeatStructure)
        {
            return await _selCarriageSeatStructureService.PutSelCarriageSeatStructure(id, selCarriageSeatStructure);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSelCarriageSeatStructure(int id)
        {
            return await _selCarriageSeatStructureService.DeleteSelCarriageSeatStructure(id);
        }
    }
}
