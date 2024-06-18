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
    public class RegisteredLocomotiveSer : IRegisteredLocomotiveSer
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public RegisteredLocomotiveSer(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<ActionResult<IEnumerable<RegisteredLocomotive>>> GetRegisteredLocomotives()
        {
            return await _vehicleDbContext.RegisteredLocomotives.ToListAsync();
        }

        public async Task<ActionResult<RegisteredLocomotive>> GetRegisteredLocomotive(int id)
        {
            var locomotive = await _vehicleDbContext.RegisteredLocomotives.FindAsync(id);
            if (locomotive == null)
            {
                return new NotFoundResult();
            }
            return locomotive;
        }

        public async Task<ActionResult<RegisteredLocomotive>> PostRegisteredLocomotive(RegisteredLocomotive locomotiveRegistration)
        {
            _vehicleDbContext.RegisteredLocomotives.Add(locomotiveRegistration);
            await _vehicleDbContext.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetRegisteredLocomotive), null, new { id = locomotiveRegistration.LocomotiveId }, locomotiveRegistration);
        }

        public async Task<ActionResult> PutRegisteredLocomotive(int id, RegisteredLocomotive locomotiveRegistration)
        {
            if (id != locomotiveRegistration.LocomotiveId)
            {
                return new BadRequestResult();
            }

            _vehicleDbContext.Entry(locomotiveRegistration).State = EntityState.Modified;

            try
            {
                await _vehicleDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_vehicleDbContext.RegisteredLocomotives.Any(e => e.LocomotiveId == id))
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

        public async Task<ActionResult> DeleteRegisteredLocomotive(int id)
        {
            var locomotive = await _vehicleDbContext.RegisteredLocomotives.FindAsync(id);
            if (locomotive == null)
            {
                return new NotFoundResult();
            }

            _vehicleDbContext.RegisteredLocomotives.Remove(locomotive);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<ActionResult<IEnumerable<RegisteredLocomotive>>> GetRegisteredLocomotivesByUserId(string userId)
        {
            var locomotives = await _vehicleDbContext.RegisteredLocomotives.Where(l => l.UserId == userId).ToListAsync();
            if (locomotives == null || !locomotives.Any())
            {
                return new NotFoundResult();
            }
            return locomotives;
        }
    }
}
