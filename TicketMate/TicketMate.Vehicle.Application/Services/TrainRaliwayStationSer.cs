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
    public class TrainRaliwayStationSer : ITrainRaliwayStationSer
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public TrainRaliwayStationSer(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<ActionResult<IEnumerable<TrainRaliwayStation>>> GetTrainRaliwayStations()
        {
            return await _vehicleDbContext.TrainRaliwayStations.ToListAsync();
        }

        public async Task<ActionResult<TrainRaliwayStation>> GetTrainRaliwayStation(int id)
        {
            var trainRaliwayStation = await _vehicleDbContext.TrainRaliwayStations.FindAsync(id);
            if (trainRaliwayStation == null)
            {
                return new NotFoundResult();
            }
            return trainRaliwayStation;
        }

        public async Task<ActionResult<IEnumerable<TrainRaliwayStation>>> GetTrainRaliwayStationsByRaliwayId(int trainRaliwayId)
        {
            var trainRaliwayStations = await _vehicleDbContext.TrainRaliwayStations
                .Where(station => station.TrainRaliwayId == trainRaliwayId)
                .ToListAsync();
            return new ActionResult<IEnumerable<TrainRaliwayStation>>(trainRaliwayStations);
        }

        public async Task<ActionResult<TrainRaliwayStation>> PostTrainRaliwayStation(TrainRaliwayStation trainRaliwayStation)
        {
            _vehicleDbContext.TrainRaliwayStations.Add(trainRaliwayStation);
            await _vehicleDbContext.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetTrainRaliwayStation), null, new { id = trainRaliwayStation.id }, trainRaliwayStation);
        }

        public async Task<ActionResult> PutTrainRaliwayStation(int id, TrainRaliwayStation trainRaliwayStation)
        {
            if (id != trainRaliwayStation.id)
            {
                return new BadRequestResult();
            }
            _vehicleDbContext.Entry(trainRaliwayStation).State = EntityState.Modified;
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

        public async Task<ActionResult> DeleteTrainRaliwayStation(int id)
        {
            var trainRaliwayStation = await _vehicleDbContext.TrainRaliwayStations.FindAsync(id);
            if (trainRaliwayStation == null)
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.TrainRaliwayStations.Remove(trainRaliwayStation);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }
    }
}
