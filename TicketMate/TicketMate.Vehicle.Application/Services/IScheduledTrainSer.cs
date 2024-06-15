using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.Application.Services
{
    public interface IScheduledTrainSer
    {
        Task<ActionResult<IEnumerable<ScheduledTrain>>> GetScheduledTrains();
        Task<ActionResult<ScheduledTrain>> GetScheduledTrain(int id);
        Task<ActionResult<IEnumerable<ScheduledTrain>>> GetScheduledTrainsByUserId(string userId);
        Task<ActionResult<ScheduledTrain>> PostScheduledTrain(ScheduledTrain scheduledTrain);
        Task<ActionResult> PutScheduledTrain(int id, ScheduledTrain scheduledTrain);
        Task<ActionResult> DeleteScheduledTrain(int id);
    }
}
