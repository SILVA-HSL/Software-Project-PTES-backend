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
    public class ScheduledLocomotiveSer : IScheduledLocomotiveSer
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public ScheduledLocomotiveSer(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<ActionResult<IEnumerable<ScheduledLocomotive>>> GetScheduledLocomotives()
        {
            return await _vehicleDbContext.ScheduledLocomotives.ToListAsync();
        }

        public async Task<ActionResult<ScheduledLocomotive>> GetScheduledLocomotive(int id)
        {
            var scheduledLocomotive = await _vehicleDbContext.ScheduledLocomotives.FindAsync(id);
            if (scheduledLocomotive == null)
            {
                return new NotFoundResult();
            }
            return scheduledLocomotive;
        }

        public async Task<ActionResult<IEnumerable<ScheduledLocomotive>>> GetScheduledLocomotivesByTrainSchedulId(int scheduledTrainSchedulId)
        {
            var scheduledLocomotives = await _vehicleDbContext.ScheduledLocomotives
                .Where(sl => sl.ScheduledTrainSchedulId == scheduledTrainSchedulId)
                .ToListAsync();
            if (scheduledLocomotives == null || !scheduledLocomotives.Any())
            {
                return new NotFoundResult();
            }
            return new ActionResult<IEnumerable<ScheduledLocomotive>>(scheduledLocomotives);
        }

        public async Task<ActionResult<ScheduledLocomotive>> PostScheduledLocomotive(ScheduledLocomotive scheduledLocomotive)
        {
            _vehicleDbContext.ScheduledLocomotives.Add(scheduledLocomotive);
            await _vehicleDbContext.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetScheduledLocomotive), null, new { id = scheduledLocomotive.Id }, scheduledLocomotive);
        }

        public async Task<ActionResult> PutScheduledLocomotive(int id, ScheduledLocomotive scheduledLocomotive)
        {
            if (id != scheduledLocomotive.Id)
            {
                return new BadRequestResult();
            }
            _vehicleDbContext.Entry(scheduledLocomotive).State = EntityState.Modified;
            try
            {
                await _vehicleDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_vehicleDbContext.ScheduledLocomotives.Any(e => e.Id == id))
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

        public async Task<ActionResult> DeleteScheduledLocomotive(int id)
        {
            var scheduledLocomotive = await _vehicleDbContext.ScheduledLocomotives.FindAsync(id);
            if (scheduledLocomotive == null)
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.ScheduledLocomotives.Remove(scheduledLocomotive);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }
    }
}
