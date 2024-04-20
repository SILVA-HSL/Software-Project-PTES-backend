using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketMate.Vehicle.API.Models;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    public interface ISelSeaStrSer
    {
        Task<ActionResult<IEnumerable<SelectedSeatStructure>>> GetSelectedSeatStructures();
        Task<ActionResult<SelectedSeatStructure>> GetSelectedSeatStructure(int id);
        Task<ActionResult<SelectedSeatStructure>> PostSelectedSeatStructure(SelectedSeatStructure seatStructure);
        Task<ActionResult> PutSelectedSeatStructure(int id, SelectedSeatStructure seatStructure);
        Task<ActionResult> DeleteSelectedSeatStructure(int id);
    }
}