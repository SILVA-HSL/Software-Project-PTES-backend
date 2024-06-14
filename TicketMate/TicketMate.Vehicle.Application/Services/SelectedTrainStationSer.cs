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
    public class SelectedTrainStationSer : ISelectedTrainStationSer
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public SelectedTrainStationSer(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<ActionResult<IEnumerable<SelectedTrainStation>>> GetSelectedTrainStations()
        {
            return await _vehicleDbContext.SelectedTrainStations.ToListAsync();
        }

        public async Task<ActionResult<SelectedTrainStation>> GetSelectedTrainStation(int id)
        {
            var selectedTrainStation = await _vehicleDbContext.SelectedTrainStations.FindAsync(id);
            if (selectedTrainStation == null)
            {
                return new NotFoundResult();
            }
            return selectedTrainStation;
        }

        public async Task<ActionResult<IEnumerable<SelectedTrainStation>>> GetSelectedTrainStationsByScheduledTrainSchedulId(int scheduledTrainSchedulId)
        {
            var selectedTrainStations = await _vehicleDbContext.SelectedTrainStations
                .Where(st => st.ScheduledTrainSchedulId == scheduledTrainSchedulId)
                .ToListAsync();

            if (!selectedTrainStations.Any())
            {
                return new NotFoundResult();
            }

            return selectedTrainStations;
        }

        public async Task<ActionResult<SelectedTrainStation>> PostSelectedTrainStation(SelectedTrainStation selectedTrainStation)
        {
            _vehicleDbContext.SelectedTrainStations.Add(selectedTrainStation);
            await _vehicleDbContext.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetSelectedTrainStation), null, new { id = selectedTrainStation.id }, selectedTrainStation);
        }

        public async Task<ActionResult> PutSelectedTrainStation(int id, SelectedTrainStation selectedTrainStation)
        {
            if (id != selectedTrainStation.id)
            {
                return new BadRequestResult();
            }
            _vehicleDbContext.Entry(selectedTrainStation).State = EntityState.Modified;
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

        public async Task<ActionResult> DeleteSelectedTrainStation(int id)
        {
            var selectedTrainStation = await _vehicleDbContext.SelectedTrainStations.FindAsync(id);
            if (selectedTrainStation == null)
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.SelectedTrainStations.Remove(selectedTrainStation);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }
    }
}
