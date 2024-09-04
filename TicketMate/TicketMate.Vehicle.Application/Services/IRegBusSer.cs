using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketMate.Vehicle.API.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    public interface IRegBusSer
    {
        Task<ActionResult<IEnumerable<RegisteredBus>>> GetRegBuses();
        Task<ActionResult<RegisteredBus>> GetRegBus(int id);
        Task<ActionResult<RegisteredBus>> PostRegBuses(RegisteredBus busRegistration);
        Task<ActionResult> PutRegBuses(int id, RegisteredBus busRegistration);
        Task<ActionResult> DeleteRegBus(int id);
        Task<ActionResult<IEnumerable<RegisteredBus>>> GetRegBusesByUserId(string userId); // New method
    }
}
