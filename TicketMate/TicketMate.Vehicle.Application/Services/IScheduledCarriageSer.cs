using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.Application.Services
{
    public interface IScheduledCarriageSer
    {
        Task<ActionResult<IEnumerable<ScheduledCarriage>>> GetScheduledCarriages();
        Task<ActionResult<ScheduledCarriage>> GetScheduledCarriage(int id);
        Task<ActionResult<ScheduledCarriage>> PostScheduledCarriage(ScheduledCarriage scheduledCarriage);
        Task<ActionResult> PutScheduledCarriage(int id, ScheduledCarriage scheduledCarriage);
        Task<ActionResult> DeleteScheduledCarriage(int id);

        // New method to get scheduled carriages by ScheduledTrainSchedulId
        Task<ActionResult<IEnumerable<ScheduledCarriage>>> GetScheduledCarriagesByTrainScheduleId(int scheduledTrainSchedulId);
    }
}
