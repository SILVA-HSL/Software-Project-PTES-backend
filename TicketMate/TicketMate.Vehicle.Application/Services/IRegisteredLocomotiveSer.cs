using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.Application.Services
{
    public interface IRegisteredLocomotiveSer
    {
        Task<ActionResult<IEnumerable<RegisteredLocomotive>>> GetRegisteredLocomotives();
        Task<ActionResult<RegisteredLocomotive>> GetRegisteredLocomotive(int id);
        Task<ActionResult<RegisteredLocomotive>> PostRegisteredLocomotive(RegisteredLocomotive locomotiveRegistration);
        Task<ActionResult> PutRegisteredLocomotive(int id, RegisteredLocomotive locomotiveRegistration);
        Task<ActionResult> DeleteRegisteredLocomotive(int id);
        Task<ActionResult<IEnumerable<RegisteredLocomotive>>> GetRegisteredLocomotivesByUserId(string userId);
    }
}
