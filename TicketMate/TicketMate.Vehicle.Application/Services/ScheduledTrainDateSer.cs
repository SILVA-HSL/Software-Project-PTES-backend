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
    public class ScheduledTrainDateSer : IScheduledTrainDateSer
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public ScheduledTrainDateSer(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<ActionResult<IEnumerable<ScheduledTrainDate>>> GetScheduledTrainDates()
        {
            return await _vehicleDbContext.ScheduledTrainDates.ToListAsync();
        }

        public async Task<ActionResult<ScheduledTrainDate>> GetScheduledTrainDate(int id)
        {
            var scheduledTrainDate = await _vehicleDbContext.ScheduledTrainDates.FindAsync(id);
            if (scheduledTrainDate == null)
            {
                return new NotFoundResult();
            }
            return scheduledTrainDate;
        }

        public async Task<ActionResult<IEnumerable<ScheduledTrainDate>>> GetScheduledTrainDatesByScheduledTrainSchedulId(int scheduledTrainSchedulId)
        {
            var scheduledTrainDates = await _vehicleDbContext.ScheduledTrainDates
                .Where(std => std.ScheduledTrainSchedulId == scheduledTrainSchedulId)
                .ToListAsync();
            if (scheduledTrainDates == null || !scheduledTrainDates.Any())
            {
                return new NotFoundResult();
            }
            return scheduledTrainDates;
        }

        public async Task<ActionResult<ScheduledTrainDate>> PostScheduledTrainDate(ScheduledTrainDate scheduledTrainDate)
        {
            _vehicleDbContext.ScheduledTrainDates.Add(scheduledTrainDate);
            await _vehicleDbContext.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetScheduledTrainDate), null, new { id = scheduledTrainDate.Id }, scheduledTrainDate);
        }

        public async Task<ActionResult> PutScheduledTrainDate(int id, ScheduledTrainDate scheduledTrainDate)
        {
            if (id != scheduledTrainDate.Id)
            {
                return new BadRequestResult();
            }
            _vehicleDbContext.Entry(scheduledTrainDate).State = EntityState.Modified;
            try
            {
                await _vehicleDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_vehicleDbContext.ScheduledTrainDates.Any(e => e.Id == id))
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

        public async Task<ActionResult> DeleteScheduledTrainDate(int id)
        {
            var scheduledTrainDate = await _vehicleDbContext.ScheduledTrainDates.FindAsync(id);
            if (scheduledTrainDate == null)
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.ScheduledTrainDates.Remove(scheduledTrainDate);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }
    }
}
