using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketMate.Vehicle.API.Models;
using TicketMate.Vehicle.Infastructure;

namespace TicketMate.Vehicle.API.Controllers
{
    public class RegBusSer : IRegBusSer
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public RegBusSer(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<ActionResult<IEnumerable<RegisteredBus>>> GetRegBuses()
        {
            if (_vehicleDbContext.RegisteredBuses == null)
            {
                return new NotFoundResult();
            }
            return await _vehicleDbContext.RegisteredBuses.ToListAsync();
        }

        public async Task<ActionResult<RegisteredBus>> GetRegBus(int id)
        {
            if (_vehicleDbContext.RegisteredBuses == null)
            {
                return new NotFoundResult();
            }
            var employee = await _vehicleDbContext.RegisteredBuses.FindAsync(id);
            if (employee == null)
            {
                return new NotFoundResult();
            }
            return employee;
        }

        public async Task<ActionResult<RegisteredBus>> PostRegBuses(RegisteredBus busRegistration)
        {
            _vehicleDbContext.RegisteredBuses.Add(busRegistration);
            await _vehicleDbContext.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetRegBus), null, new { id = busRegistration.BusId }, busRegistration);
        }

        public async Task<ActionResult> PutRegBuses(int id, RegisteredBus busRegistration)
        {
            if (id != busRegistration.BusId)
            {
                return new BadRequestResult();
            }
            _vehicleDbContext.Entry(busRegistration).State = EntityState.Modified;
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

        public async Task<ActionResult> DeleteRegBus(int id)
        {
            if (_vehicleDbContext.RegisteredBuses == null)
            {
                return new NotFoundResult();
            }
            var bus = await _vehicleDbContext.RegisteredBuses.FindAsync(id);
            if (bus == null)
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.RegisteredBuses.Remove(bus);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }
    }
}
