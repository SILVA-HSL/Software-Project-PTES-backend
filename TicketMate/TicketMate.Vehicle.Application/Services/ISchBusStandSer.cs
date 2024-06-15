using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.Application.Services
{
    public interface ISchBusStandSer
    {
        Task<ActionResult<IEnumerable<SelectedBusStand>>> GetSelectedBusStands();
        Task<ActionResult<SelectedBusStand>> GetSelectedBusStand(int id);
        Task<ActionResult<SelectedBusStand>> PostSelectedBusStand(SelectedBusStand selectedBusStand);
        Task<ActionResult> PutSelectedBusStand(int id, SelectedBusStand selectedBusStand);
        Task<ActionResult> DeleteSelectedBusStand(int id);

        Task<ActionResult<IEnumerable<SelectedBusStand>>> GetSelectedBusStandsByScheduleId(int scheduleId);
        Task<ActionResult> PutSelectedBusStandByScheduleId(int scheduleId, SelectedBusStand selectedBusStand);
        Task<ActionResult> DeleteSelectedBusStandsByScheduleId(int scheduleId);
    }
}
