using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.Application.Services
{
    public interface IScheduledLocomotiveSer
    {
        Task<ActionResult<IEnumerable<ScheduledLocomotive>>> GetScheduledLocomotives();
        Task<ActionResult<ScheduledLocomotive>> GetScheduledLocomotive(int id);
        Task<ActionResult<IEnumerable<ScheduledLocomotive>>> GetScheduledLocomotivesByTrainSchedulId(int scheduledTrainSchedulId);
        Task<ActionResult<ScheduledLocomotive>> PostScheduledLocomotive(ScheduledLocomotive scheduledLocomotive);
        Task<ActionResult> PutScheduledLocomotive(int id, ScheduledLocomotive scheduledLocomotive);
        Task<ActionResult> DeleteScheduledLocomotive(int id);
    }
}
