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
    public class SchBusStandSer : ISchBusStandSer
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public SchBusStandSer(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<ActionResult<IEnumerable<SelectedBusStand>>> GetSelectedBusStands()
        {
            return await _vehicleDbContext.SelectedBusStands.ToListAsync();
        }

        public async Task<ActionResult<SelectedBusStand>> GetSelectedBusStand(int id)
        {
            var selectedBusStand = await _vehicleDbContext.SelectedBusStands.FindAsync(id);
            if (selectedBusStand == null)
            {
                return new NotFoundResult();
            }
            return selectedBusStand;
        }

        public async Task<ActionResult<SelectedBusStand>> PostSelectedBusStand(SelectedBusStand selectedBusStand)
        {
            _vehicleDbContext.SelectedBusStands.Add(selectedBusStand);
            await _vehicleDbContext.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetSelectedBusStand), null, new { id = selectedBusStand.Id }, selectedBusStand);
        }

        public async Task<ActionResult> PutSelectedBusStand(int id, SelectedBusStand selectedBusStand)
        {
            if (id != selectedBusStand.Id)
            {
                return new BadRequestResult();
            }
            _vehicleDbContext.Entry(selectedBusStand).State = EntityState.Modified;
            try
            {
                await _vehicleDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SelectedBusStandExists(id))
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

        public async Task<ActionResult> DeleteSelectedBusStand(int id)
        {
            var selectedBusStand = await _vehicleDbContext.SelectedBusStands.FindAsync(id);
            if (selectedBusStand == null)
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.SelectedBusStands.Remove(selectedBusStand);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<ActionResult<IEnumerable<SelectedBusStand>>> GetSelectedBusStandsByScheduleId(int scheduleId)
        {
            var selectedBusStands = await _vehicleDbContext.SelectedBusStands
                .Where(s => s.ScheduledBusScheduleId == scheduleId)
                .ToListAsync();
            if (selectedBusStands == null || selectedBusStands.Count == 0)
            {
                return new NotFoundResult();
            }
            return new ActionResult<IEnumerable<SelectedBusStand>>(selectedBusStands);
        }

        public async Task<ActionResult> PutSelectedBusStandByScheduleId(int scheduleId, SelectedBusStand selectedBusStand)
        {
            var selectedBusStandToUpdate = await _vehicleDbContext.SelectedBusStands
                .FirstOrDefaultAsync(s => s.ScheduledBusScheduleId == scheduleId);
            if (selectedBusStandToUpdate == null)
            {
                return new NotFoundResult();
            }
            selectedBusStandToUpdate.BusStation = selectedBusStand.BusStation;
            selectedBusStandToUpdate.StandArrivalTime = selectedBusStand.StandArrivalTime;

            _vehicleDbContext.Entry(selectedBusStandToUpdate).State = EntityState.Modified;
            await _vehicleDbContext.SaveChangesAsync();
            return new OkResult();
        }

        public async Task<ActionResult> DeleteSelectedBusStandsByScheduleId(int scheduleId)
        {
            var selectedBusStands = await _vehicleDbContext.SelectedBusStands
                .Where(s => s.ScheduledBusScheduleId == scheduleId)
                .ToListAsync();
            if (selectedBusStands == null || selectedBusStands.Count == 0)
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.SelectedBusStands.RemoveRange(selectedBusStands);
            await _vehicleDbContext.SaveChangesAsync();
            return new OkResult();
        }

        private bool SelectedBusStandExists(int id)
        {
            return _vehicleDbContext.SelectedBusStands.Any(e => e.Id == id);
        }
    }
}
