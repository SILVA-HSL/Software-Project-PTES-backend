using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.Application.Services
{
    public interface IScheduledTrainDateSer
    {
        Task<ActionResult<IEnumerable<ScheduledTrainDate>>> GetScheduledTrainDates();
        Task<ActionResult<ScheduledTrainDate>> GetScheduledTrainDate(int id);
        Task<ActionResult<IEnumerable<ScheduledTrainDate>>> GetScheduledTrainDatesByScheduledTrainSchedulId(int scheduledTrainSchedulId);
        Task<ActionResult<ScheduledTrainDate>> PostScheduledTrainDate(ScheduledTrainDate scheduledTrainDate);
        Task<ActionResult> PutScheduledTrainDate(int id, ScheduledTrainDate scheduledTrainDate);
        Task<ActionResult> DeleteScheduledTrainDate(int id);
    }
}
