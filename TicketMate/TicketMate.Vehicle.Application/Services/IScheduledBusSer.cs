using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.Application.Services
{
    public interface IScheduledBusSer
    {
        Task<ActionResult<IEnumerable<ScheduledBus>>> GetScheduledBuses();
        Task<ActionResult<ScheduledBus>> GetScheduledBus(int id);
        Task<ActionResult<ScheduledBus>> PostScheduledBus(ScheduledBus scheduledBus);
        Task<ActionResult> PutScheduledBus(int id, ScheduledBus scheduledBus);
        Task<ActionResult> DeleteScheduledBus(int id);

        // New method to get scheduled buses by UserId
        Task<ActionResult<IEnumerable<ScheduledBus>>> GetScheduledBusesByUserId(string userId);
    }
}
