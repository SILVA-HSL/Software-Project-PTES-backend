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
    public class ScheduledCarriageSer : IScheduledCarriageSer
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public ScheduledCarriageSer(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<ActionResult<IEnumerable<ScheduledCarriage>>> GetScheduledCarriages()
        {
            return await _vehicleDbContext.ScheduledCarriages.ToListAsync();
        }

        public async Task<ActionResult<ScheduledCarriage>> GetScheduledCarriage(int id)
        {
            var scheduledCarriage = await _vehicleDbContext.ScheduledCarriages.FindAsync(id);
            if (scheduledCarriage == null)
            {
                return new NotFoundResult();
            }
            return scheduledCarriage;
        }

        public async Task<ActionResult<ScheduledCarriage>> PostScheduledCarriage(ScheduledCarriage scheduledCarriage)
        {
            _vehicleDbContext.ScheduledCarriages.Add(scheduledCarriage);
            await _vehicleDbContext.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetScheduledCarriage), null, new { id = scheduledCarriage.Id }, scheduledCarriage);
        }

        public async Task<ActionResult> PutScheduledCarriage(int id, ScheduledCarriage scheduledCarriage)
        {
            if (id != scheduledCarriage.Id)
            {
                return new BadRequestResult();
            }
            _vehicleDbContext.Entry(scheduledCarriage).State = EntityState.Modified;
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

        public async Task<ActionResult> DeleteScheduledCarriage(int id)
        {
            var scheduledCarriage = await _vehicleDbContext.ScheduledCarriages.FindAsync(id);
            if (scheduledCarriage == null)
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.ScheduledCarriages.Remove(scheduledCarriage);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }

        // Implementation of the new method
        public async Task<ActionResult<IEnumerable<ScheduledCarriage>>> GetScheduledCarriagesByTrainScheduleId(int scheduledTrainSchedulId)
        {
            var scheduledCarriages = await _vehicleDbContext.ScheduledCarriages
                .Where(sc => sc.ScheduledTrainSchedulId == scheduledTrainSchedulId)
                .ToListAsync();

            return scheduledCarriages;
        }
    }
}
