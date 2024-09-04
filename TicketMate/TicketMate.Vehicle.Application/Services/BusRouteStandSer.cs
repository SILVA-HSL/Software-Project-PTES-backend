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
    public class BusRouteStandSer : IBusRouteStandSer
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public BusRouteStandSer(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<ActionResult<IEnumerable<BusRouteStand>>> GetBusRouteStands()
        {
            return await _vehicleDbContext.BusRouteStands.ToListAsync();
        }

        public async Task<ActionResult<BusRouteStand>> GetBusRouteStand(int id)
        {
            var busRouteStand = await _vehicleDbContext.BusRouteStands.FindAsync(id);
            if (busRouteStand == null)
            {
                return new NotFoundResult();
            }
            return busRouteStand;
        }

        public async Task<ActionResult<IEnumerable<BusRouteStand>>> GetBusRouteStandsByRouteId(int routeId)
        {
            var busRouteStands = await _vehicleDbContext.BusRouteStands
                .Where(b => b.BusRouteRoutId == routeId).ToListAsync();
            if (busRouteStands == null || !busRouteStands.Any())
            {
                return new NotFoundResult();
            }
            return busRouteStands;
        }

        public async Task<ActionResult<BusRouteStand>> PostBusRouteStand(BusRouteStand busRouteStand)
        {
            _vehicleDbContext.BusRouteStands.Add(busRouteStand);
            await _vehicleDbContext.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetBusRouteStand), null, new { id = busRouteStand.Id }, busRouteStand);
        }

        public async Task<ActionResult> PutBusRouteStand(int id, BusRouteStand busRouteStand)
        {
            if (id != busRouteStand.Id)
            {
                return new BadRequestResult();
            }
            _vehicleDbContext.Entry(busRouteStand).State = EntityState.Modified;
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

        public async Task<ActionResult> DeleteBusRouteStand(int id)
        {
            var busRouteStand = await _vehicleDbContext.BusRouteStands.FindAsync(id);
            if (busRouteStand == null)
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.BusRouteStands.Remove(busRouteStand);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<ActionResult> DeleteBusRouteStandsByRouteId(int routeId)
        {
            var busRouteStands = await _vehicleDbContext.BusRouteStands
                .Where(b => b.BusRouteRoutId == routeId).ToListAsync();
            if (busRouteStands == null || !busRouteStands.Any())
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.BusRouteStands.RemoveRange(busRouteStands);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }
    }
}
