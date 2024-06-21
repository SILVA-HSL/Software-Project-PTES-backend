using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.Application.Services
{
    public interface IScheduledBusDateSer
    {
        Task<ActionResult<IEnumerable<ScheduledBusDate>>> GetScheduledBusDates();
        Task<ActionResult<ScheduledBusDate>> GetScheduledBusDate(int id);
        Task<ActionResult<IEnumerable<ScheduledBusDate>>> GetScheduledBusDatesByScheduleId(int scheduleId);
        Task<ActionResult<ScheduledBusDate>> PostScheduledBusDate(ScheduledBusDate scheduledBusDate);
        Task<ActionResult> PutScheduledBusDate(int id, ScheduledBusDate scheduledBusDate);
        Task<ActionResult> DeleteScheduledBusDate(int id);
        Task<ActionResult> DeleteScheduledBusDatesByScheduleId(int scheduleId);
    }
}
