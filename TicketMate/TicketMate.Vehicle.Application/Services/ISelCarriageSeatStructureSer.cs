using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.Application.Services
{
    public interface ISelCarriageSeatStructureSer
    {
        Task<ActionResult<IEnumerable<SelCarriageSeatStructure>>> GetSelCarriageSeatStructures();
        Task<ActionResult<SelCarriageSeatStructure>> GetSelCarriageSeatStructure(int id);
        Task<ActionResult<IEnumerable<SelCarriageSeatStructure>>> GetSelCarriageSeatStructuresByCarriageId(int carriageId);
        Task<ActionResult> DeleteSelCarriageSeatStructureByCarriageId(int carriageId);
        Task<ActionResult<SelCarriageSeatStructure>> PostSelCarriageSeatStructure(SelCarriageSeatStructure selCarriageSeatStructure);
        Task<ActionResult> PutSelCarriageSeatStructure(int id, SelCarriageSeatStructure selCarriageSeatStructure);
        Task<ActionResult> DeleteSelCarriageSeatStructure(int id);
    }
}
