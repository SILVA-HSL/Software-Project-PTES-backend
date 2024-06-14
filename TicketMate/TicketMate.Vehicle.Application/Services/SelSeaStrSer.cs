using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketMate.Vehicle.API.Models;
using TicketMate.Vehicle.Domain.Models;
using TicketMate.Vehicle.Infastructure;

namespace TicketMate.Vehicle.API.Controllers
{
    public class SelSeaStrSer : ISelSeaStrSer
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public SelSeaStrSer(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<ActionResult<IEnumerable<SelectedSeatStructure>>> GetSelectedSeatStructures()
        {
            if (_vehicleDbContext.SelectedSeatStructures == null)
            {
                return new NotFoundResult();
            }
            return await _vehicleDbContext.SelectedSeatStructures.ToListAsync();
        }

        public async Task<ActionResult<SelectedSeatStructure>> GetSelectedSeatStructure(int id)
        {
            if (_vehicleDbContext.SelectedSeatStructures == null)
            {
                return new NotFoundResult();
            }
            var seatStructure = await _vehicleDbContext.SelectedSeatStructures.FindAsync(id);
            if (seatStructure == null)
            {
                return new NotFoundResult();
            }
            return seatStructure;
        }

        public async Task<ActionResult<IEnumerable<SelectedSeatStructure>>> GetSelectedSeatStructuresByBusId(int busId)
        {
            var seatStructures = await _vehicleDbContext.SelectedSeatStructures
                .Where(s => s.RegisteredBusBusId == busId)
                .ToListAsync();

            if (seatStructures == null || !seatStructures.Any())
            {
                return new NotFoundResult();
            }

            return seatStructures;
        }


        public async Task<ActionResult<SelectedSeatStructure>> PostSelectedSeatStructure(SelectedSeatStructure seatStructure)
        {
            _vehicleDbContext.SelectedSeatStructures.Add(seatStructure);
            await _vehicleDbContext.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetSelectedSeatStructure), null, new { id = seatStructure.Id }, seatStructure);
        }

        public async Task<ActionResult> PutSelectedSeatStructure(int id, SelectedSeatStructure seatStructure)
        {
            if (id != seatStructure.Id)
            {
                return new BadRequestResult();
            }
            _vehicleDbContext.Entry(seatStructure).State = EntityState.Modified;
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

        public async Task<ActionResult> DeleteSelectedSeatStructure(int id)
        {
            if (_vehicleDbContext.SelectedSeatStructures == null)
            {
                return new NotFoundResult();
            }
            var seatStructure = await _vehicleDbContext.SelectedSeatStructures.FindAsync(id);
            if (seatStructure == null)
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.SelectedSeatStructures.Remove(seatStructure);
            await _vehicleDbContext.SaveChangesAsync();

            return new OkResult();
        }
    }
}