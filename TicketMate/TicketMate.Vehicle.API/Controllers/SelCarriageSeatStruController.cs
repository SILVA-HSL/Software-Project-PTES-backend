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

        //[Authorize(Roles = "Admin,Owner")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelCarriageSeatStructure>>> GetSelCarriageSeatStructures()
        {
            return await _selCarriageSeatStructureService.GetSelCarriageSeatStructures();
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpGet("{id}")]
        public async Task<ActionResult<SelCarriageSeatStructure>> GetSelCarriageSeatStructure(int id)
        {
            return await _selCarriageSeatStructureService.GetSelCarriageSeatStructure(id);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpGet("ByCarriageId/{carriageId}")]
        public async Task<ActionResult<IEnumerable<SelCarriageSeatStructure>>> GetSelCarriageSeatStructuresByCarriageId(int carriageId)
        {
            return await _selCarriageSeatStructureService.GetSelCarriageSeatStructuresByCarriageId(carriageId);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpDelete("ByCarriageId/{carriageId}")]
        public async Task<ActionResult> DeleteSelCarriageSeatStructureByCarriageId(int carriageId)
        {
            return await _selCarriageSeatStructureService.DeleteSelCarriageSeatStructureByCarriageId(carriageId);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpPost]
        public async Task<ActionResult<SelCarriageSeatStructure>> PostSelCarriageSeatStructure(SelCarriageSeatStructure selCarriageSeatStructure)
        {
            return await _selCarriageSeatStructureService.PostSelCarriageSeatStructure(selCarriageSeatStructure);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutSelCarriageSeatStructure(int id, SelCarriageSeatStructure selCarriageSeatStructure)
        {
            return await _selCarriageSeatStructureService.PutSelCarriageSeatStructure(id, selCarriageSeatStructure);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSelCarriageSeatStructure(int id)
        {
            return await _selCarriageSeatStructureService.DeleteSelCarriageSeatStructure(id);
        }
    }
}
