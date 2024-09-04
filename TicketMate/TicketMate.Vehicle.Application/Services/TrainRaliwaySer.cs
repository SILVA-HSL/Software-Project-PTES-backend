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
    public class TrainRaliwaySer : ITrainRaliwaySer
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public TrainRaliwaySer(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<ActionResult<IEnumerable<TrainRaliway>>> GetTrainRaliways()
        {
            return await _vehicleDbContext.TrainRaliways.ToListAsync();
        }

        public async Task<ActionResult<TrainRaliway>> GetTrainRaliway(int id)
        {
            var trainRaliway = await _vehicleDbContext.TrainRaliways.FindAsync(id);
            if (trainRaliway == null)
            {
                return new NotFoundResult();
            }
            return trainRaliway;
        }

        public async Task<ActionResult<TrainRaliway>> GetTrainRaliwayByNo(int railwayNo)
        {
            var trainRaliway = await _vehicleDbContext.TrainRaliways.FirstOrDefaultAsync(t => t.RailwayNo == railwayNo);
            if (trainRaliway == null)
            {
                return new NotFoundResult();
            }
            return trainRaliway;
        }

        public async Task<ActionResult<TrainRaliway>> PostTrainRaliway(TrainRaliway trainRaliway)
        {
            _vehicleDbContext.TrainRaliways.Add(trainRaliway);
            await _vehicleDbContext.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetTrainRaliway), null, new { id = trainRaliway.Id }, trainRaliway);
        }

        public async Task<ActionResult> PutTrainRaliway(int id, TrainRaliway trainRaliway)
        {
            if (id != trainRaliway.Id)
            {
                return new BadRequestResult();
            }
            _vehicleDbContext.Entry(trainRaliway).State = EntityState.Modified;
            try
            {
                await _vehicleDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainRaliwayExists(id))
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

        public async Task<ActionResult> DeleteTrainRaliway(int id)
        {
            var trainRaliway = await _vehicleDbContext.TrainRaliways.FindAsync(id);
            if (trainRaliway == null)
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.TrainRaliways.Remove(trainRaliway);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }

        private bool TrainRaliwayExists(int id)
        {
            return _vehicleDbContext.TrainRaliways.Any(e => e.Id == id);
        }
    }
}
