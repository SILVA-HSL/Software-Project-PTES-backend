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
    public class ScheduledTrainSer : IScheduledTrainSer
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public ScheduledTrainSer(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<ActionResult<IEnumerable<ScheduledTrain>>> GetScheduledTrains()
        {
            return await _vehicleDbContext.ScheduledTrains.ToListAsync();
        }

        public async Task<ActionResult<ScheduledTrain>> GetScheduledTrain(int id)
        {
            var scheduledTrain = await _vehicleDbContext.ScheduledTrains.FindAsync(id);
            if (scheduledTrain == null)
            {
                return new NotFoundResult();
            }
            return scheduledTrain;
        }

        public async Task<ActionResult<IEnumerable<ScheduledTrain>>> GetScheduledTrainsByUserId(string userId)
        {
            var scheduledTrains = await _vehicleDbContext.ScheduledTrains
                .Where(st => st.UserId == userId)
                .ToListAsync();

            if (scheduledTrains == null || !scheduledTrains.Any())
            {
                return new NotFoundResult();
            }

            return new ActionResult<IEnumerable<ScheduledTrain>>(scheduledTrains);
        }

        public async Task<ActionResult<ScheduledTrain>> PostScheduledTrain(ScheduledTrain scheduledTrain)
        {
            _vehicleDbContext.ScheduledTrains.Add(scheduledTrain);
            await _vehicleDbContext.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetScheduledTrain), null, new { id = scheduledTrain.SchedulId }, scheduledTrain);
        }

        public async Task<ActionResult> PutScheduledTrain(int id, ScheduledTrain scheduledTrain)
        {
            if (id != scheduledTrain.SchedulId)
            {
                return new BadRequestResult();
            }
            _vehicleDbContext.Entry(scheduledTrain).State = EntityState.Modified;
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

        public async Task<ActionResult> DeleteScheduledTrain(int id)
        {
            var scheduledTrain = await _vehicleDbContext.ScheduledTrains.FindAsync(id);
            if (scheduledTrain == null)
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.ScheduledTrains.Remove(scheduledTrain);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }
    }
}
