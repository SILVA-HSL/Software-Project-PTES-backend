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
    public class RegisteredCarriageSer : IRegisteredCarriageSer
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public RegisteredCarriageSer(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<ActionResult<IEnumerable<RegisteredCarriage>>> GetRegisteredCarriages()
        {
            return await _vehicleDbContext.RegisteredCarriages.ToListAsync();
        }

        public async Task<ActionResult<RegisteredCarriage>> GetRegisteredCarriage(int id)
        {
            var registeredCarriage = await _vehicleDbContext.RegisteredCarriages.FindAsync(id);
            if (registeredCarriage == null)
            {
                return new NotFoundResult();
            }
            return registeredCarriage;
        }

        public async Task<ActionResult<RegisteredCarriage>> PostRegisteredCarriage(RegisteredCarriage registeredCarriage)
        {
            _vehicleDbContext.RegisteredCarriages.Add(registeredCarriage);
            await _vehicleDbContext.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetRegisteredCarriage), null, new { id = registeredCarriage.CarriageId }, registeredCarriage);
        }

        public async Task<ActionResult> PutRegisteredCarriage(int id, RegisteredCarriage registeredCarriage)
        {
            if (id != registeredCarriage.CarriageId)
            {
                return new BadRequestResult();
            }
            _vehicleDbContext.Entry(registeredCarriage).State = EntityState.Modified;
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

        public async Task<ActionResult> DeleteRegisteredCarriage(int id)
        {
            var registeredCarriage = await _vehicleDbContext.RegisteredCarriages.FindAsync(id);
            if (registeredCarriage == null)
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.RegisteredCarriages.Remove(registeredCarriage);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }

        // New methods for UserId
        public async Task<ActionResult<IEnumerable<RegisteredCarriage>>> GetRegisteredCarriagesByUserId(string userId)
        {
            var carriages = await _vehicleDbContext.RegisteredCarriages
                .Where(rc => rc.UserId == userId)
                .ToListAsync();
            return new ActionResult<IEnumerable<RegisteredCarriage>>(carriages);
        }

        public async Task<ActionResult> DeleteRegisteredCarriagesByUserId(string userId)
        {
            var carriages = await _vehicleDbContext.RegisteredCarriages
                .Where(rc => rc.UserId == userId)
                .ToListAsync();

            if (carriages.Count == 0)
            {
                return new NotFoundResult();
            }

            _vehicleDbContext.RegisteredCarriages.RemoveRange(carriages);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }
    }
}
