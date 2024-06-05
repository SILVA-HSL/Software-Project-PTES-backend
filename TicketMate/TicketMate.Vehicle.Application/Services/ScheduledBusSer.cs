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
    public class ScheduledBusSer : IScheduledBusSer
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public ScheduledBusSer(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<ActionResult<IEnumerable<ScheduledBus>>> GetScheduledBuses()
        {
            return await _vehicleDbContext.ScheduledBuses.ToListAsync();
        }

        public async Task<ActionResult<ScheduledBus>> GetScheduledBus(int id)
        {
            var scheduledBus = await _vehicleDbContext.ScheduledBuses.FindAsync(id);
            if (scheduledBus == null)
            {
                return new NotFoundResult();
            }
            return scheduledBus;
        }

        public async Task<ActionResult<ScheduledBus>> PostScheduledBus(ScheduledBus scheduledBus)
        {
            _vehicleDbContext.ScheduledBuses.Add(scheduledBus);
            await _vehicleDbContext.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetScheduledBus), null, new { id = scheduledBus.ScheduleId }, scheduledBus);
        }

        public async Task<ActionResult> PutScheduledBus(int id, ScheduledBus scheduledBus)
        {
            if (id != scheduledBus.ScheduleId)
            {
                return new BadRequestResult();
            }
            _vehicleDbContext.Entry(scheduledBus).State = EntityState.Modified;
            try
            {
                await _vehicleDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return new OkResult();
        }

        public async Task<ActionResult> DeleteScheduledBus(int id)
        {
            var scheduledBus = await _vehicleDbContext.ScheduledBuses.FindAsync(id);
            if (scheduledBus == null)
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.ScheduledBuses.Remove(scheduledBus);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<ActionResult<IEnumerable<ScheduledBus>>> GetScheduledBusesByUserId(string userId)
        {
            var scheduledBuses = await _vehicleDbContext.ScheduledBuses
                .Where(sb => sb.UserId == userId)
                .ToListAsync();
            return new ActionResult<IEnumerable<ScheduledBus>>(scheduledBuses);
        }
    }
}
