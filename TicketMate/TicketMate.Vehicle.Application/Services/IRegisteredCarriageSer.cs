using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.Application.Services
{
    public interface IRegisteredCarriageSer
    {
        Task<ActionResult<IEnumerable<RegisteredCarriage>>> GetRegisteredCarriages();
        Task<ActionResult<RegisteredCarriage>> GetRegisteredCarriage(int id);
        Task<ActionResult<RegisteredCarriage>> PostRegisteredCarriage(RegisteredCarriage registeredCarriage);
        Task<ActionResult> PutRegisteredCarriage(int id, RegisteredCarriage registeredCarriage);
        Task<ActionResult> DeleteRegisteredCarriage(int id);

        // New methods for UserId
        Task<ActionResult<IEnumerable<RegisteredCarriage>>> GetRegisteredCarriagesByUserId(string userId);
        Task<ActionResult> DeleteRegisteredCarriagesByUserId(string userId);
    }
}
