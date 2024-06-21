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
    public class BusRouteSer : IBusRouteSer
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public BusRouteSer(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<ActionResult<IEnumerable<BusRoute>>> GetBusRoutes()
        {
            return await _vehicleDbContext.BusRoutes.ToListAsync();
        }

        public async Task<ActionResult<BusRoute>> GetBusRoute(int id)
        {
            var busRoute = await _vehicleDbContext.BusRoutes.FindAsync(id);
            if (busRoute == null)
            {
                return new NotFoundResult();
            }
            return busRoute;
        }

        public async Task<ActionResult<BusRoute>> GetBusRouteByRoutNo(string routNo)
        {
            var busRoute = await _vehicleDbContext.BusRoutes.FirstOrDefaultAsync(br => br.RoutNo == routNo);
            if (busRoute == null)
            {
                return new NotFoundResult();
            }
            return busRoute;
        }

        public async Task<ActionResult<BusRoute>> PostBusRoute(BusRoute busRoute)
        {
            _vehicleDbContext.BusRoutes.Add(busRoute);
            await _vehicleDbContext.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetBusRoute), null, new { id = busRoute.RoutId }, busRoute);
        }

        public async Task<ActionResult> PutBusRoute(int id, BusRoute busRoute)
        {
            if (id != busRoute.RoutId)
            {
                return new BadRequestResult();
            }
            _vehicleDbContext.Entry(busRoute).State = EntityState.Modified;
            try
            {
                await _vehicleDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_vehicleDbContext.BusRoutes.Any(e => e.RoutId == id))
                {
                    return new NotFoundResult();
                }
                throw;
            }
            return new OkResult();
        }

        public async Task<ActionResult> DeleteBusRoute(int id)
        {
            var busRoute = await _vehicleDbContext.BusRoutes.FindAsync(id);
            if (busRoute == null)
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.BusRoutes.Remove(busRoute);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<ActionResult> DeleteBusRouteByRoutNo(string routNo)
        {
            var busRoute = await _vehicleDbContext.BusRoutes.FirstOrDefaultAsync(br => br.RoutNo == routNo);
            if (busRoute == null)
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.BusRoutes.Remove(busRoute);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }
    }
}
