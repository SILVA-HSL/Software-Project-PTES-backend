using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Vehicle.Domain.Models;
using TicketMate.Vehicle.Infastructure;

namespace TicketMate.Vehicle.Application.Services
{
    public class ScheduledBusDateSer : IScheduledBusDateSer
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public ScheduledBusDateSer(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<ActionResult<IEnumerable<ScheduledBusDate>>> GetScheduledBusDates()
        {
            return await _vehicleDbContext.ScheduledBusDates.ToListAsync();
        }

        public async Task<ActionResult<ScheduledBusDate>> GetScheduledBusDate(int id)
        {
            var scheduledBusDate = await _vehicleDbContext.ScheduledBusDates.FindAsync(id);
            if (scheduledBusDate == null)
            {
                return new NotFoundResult();
            }
            return scheduledBusDate;
        }

        public async Task<ActionResult<IEnumerable<ScheduledBusDate>>> GetScheduledBusDatesByScheduleId(int scheduleId)
        {
            var scheduledBusDates = await _vehicleDbContext.ScheduledBusDates
                .Where(s => s.ScheduledBusScheduleId == scheduleId)
                .ToListAsync();
            if (scheduledBusDates == null || !scheduledBusDates.Any())
            {
                return new NotFoundResult();
            }
            return new ActionResult<IEnumerable<ScheduledBusDate>>(scheduledBusDates);
        }

        public async Task<ActionResult<ScheduledBusDate>> PostScheduledBusDate(ScheduledBusDate scheduledBusDate)
        {
            _vehicleDbContext.ScheduledBusDates.Add(scheduledBusDate);
            await _vehicleDbContext.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetScheduledBusDate), null, new { id = scheduledBusDate.Id }, scheduledBusDate);
        }

        public async Task<ActionResult> PutScheduledBusDate(int id, ScheduledBusDate scheduledBusDate)
        {
            if (id != scheduledBusDate.Id)
            {
                return new BadRequestResult();
            }
            _vehicleDbContext.Entry(scheduledBusDate).State = EntityState.Modified;
            try
            {
                await _vehicleDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_vehicleDbContext.ScheduledBusDates.Any(e => e.Id == id))
                {
                    return new NotFoundResult();
                }
                else
                {
                    throw;
                }
            }
            return new OkResult();
        }

        public async Task<ActionResult> DeleteScheduledBusDate(int id)
        {
            var scheduledBusDate = await _vehicleDbContext.ScheduledBusDates.FindAsync(id);
            if (scheduledBusDate == null)
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.ScheduledBusDates.Remove(scheduledBusDate);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<ActionResult> DeleteScheduledBusDatesByScheduleId(int scheduleId)
        {
            var scheduledBusDates = await _vehicleDbContext.ScheduledBusDates
                .Where(s => s.ScheduledBusScheduleId == scheduleId)
                .ToListAsync();
            if (scheduledBusDates == null || !scheduledBusDates.Any())
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.ScheduledBusDates.RemoveRange(scheduledBusDates);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }
    }
}
