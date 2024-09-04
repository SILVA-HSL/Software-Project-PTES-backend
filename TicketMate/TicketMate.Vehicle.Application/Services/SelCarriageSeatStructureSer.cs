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
    public class SelCarriageSeatStructureSer : ISelCarriageSeatStructureSer
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public SelCarriageSeatStructureSer(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<ActionResult<IEnumerable<SelCarriageSeatStructure>>> GetSelCarriageSeatStructures()
        {
            return await _vehicleDbContext.SelCarriageSeatStructures.ToListAsync();
        }

        public async Task<ActionResult<SelCarriageSeatStructure>> GetSelCarriageSeatStructure(int id)
        {
            var selCarriageSeatStructure = await _vehicleDbContext.SelCarriageSeatStructures.FindAsync(id);
            if (selCarriageSeatStructure == null)
            {
                return new NotFoundResult();
            }
            return selCarriageSeatStructure;
        }

        public async Task<ActionResult<IEnumerable<SelCarriageSeatStructure>>> GetSelCarriageSeatStructuresByCarriageId(int carriageId)
        {
            var selCarriageSeatStructures = await _vehicleDbContext.SelCarriageSeatStructures
                .Where(s => s.RegisteredCarriageCarriageId == carriageId)
                .ToListAsync();

            if (selCarriageSeatStructures == null || !selCarriageSeatStructures.Any())
            {
                return new NotFoundResult();
            }

            return selCarriageSeatStructures;
        }

        public async Task<ActionResult> DeleteSelCarriageSeatStructureByCarriageId(int carriageId)
        {
            var selCarriageSeatStructures = await _vehicleDbContext.SelCarriageSeatStructures
                .Where(s => s.RegisteredCarriageCarriageId == carriageId)
                .ToListAsync();

            if (selCarriageSeatStructures == null || !selCarriageSeatStructures.Any())
            {
                return new NotFoundResult();
            }

            _vehicleDbContext.SelCarriageSeatStructures.RemoveRange(selCarriageSeatStructures);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<ActionResult<SelCarriageSeatStructure>> PostSelCarriageSeatStructure(SelCarriageSeatStructure selCarriageSeatStructure)
        {
            _vehicleDbContext.SelCarriageSeatStructures.Add(selCarriageSeatStructure);
            await _vehicleDbContext.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetSelCarriageSeatStructure), null, new { id = selCarriageSeatStructure.Id }, selCarriageSeatStructure);
        }

        public async Task<ActionResult> PutSelCarriageSeatStructure(int id, SelCarriageSeatStructure selCarriageSeatStructure)
        {
            if (id != selCarriageSeatStructure.Id)
            {
                return new BadRequestResult();
            }

            _vehicleDbContext.Entry(selCarriageSeatStructure).State = EntityState.Modified;
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

        public async Task<ActionResult> DeleteSelCarriageSeatStructure(int id)
        {
            var selCarriageSeatStructure = await _vehicleDbContext.SelCarriageSeatStructures.FindAsync(id);
            if (selCarriageSeatStructure == null)
            {
                return new NotFoundResult();
            }

            _vehicleDbContext.SelCarriageSeatStructures.Remove(selCarriageSeatStructure);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }
    }
}
