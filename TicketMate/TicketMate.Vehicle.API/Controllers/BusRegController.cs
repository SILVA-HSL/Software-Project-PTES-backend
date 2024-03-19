using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketMate.Vehicle.API.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusRegController : ControllerBase
    {
        private readonly RegisteredBusesContext _registeredBusesContext;

        public BusRegController(RegisteredBusesContext busRegistrationContext)
        {
            _registeredBusesContext = busRegistrationContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisteredBuses>>> GetRegBuses()
        {
            if (_registeredBusesContext.Buses == null)
            {
                return NotFound();
            }
            return await _registeredBusesContext.Buses.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisteredBuses>> GetRegBus(int id)
        {
            if (_registeredBusesContext.Buses == null)
            {
                return NotFound();
            }
            var employee = await _registeredBusesContext.Buses.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }
        [HttpPost]
        public async Task<ActionResult<RegisteredBuses>> PostRegBuses(RegisteredBuses busRegistration)
        {
            _registeredBusesContext.Buses.Add(busRegistration);
            await _registeredBusesContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRegBus), new { id = busRegistration.BusId }, busRegistration);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutRegBuses(int id, RegisteredBuses busRegistration)
        {
            if (id != busRegistration.BusId)
            {
                return BadRequest();
            }
            _registeredBusesContext.Entry(busRegistration).State = EntityState.Modified;
            try
            {
                await _registeredBusesContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRegBus(int id)
        {
            if (_registeredBusesContext.Buses == null)
            {
                return NotFound();
            }
            var bus = await _registeredBusesContext.Buses.FindAsync(id);
            if (bus == null)
            {
                return NotFound();
            }
            _registeredBusesContext.Buses.Remove(bus);
            await _registeredBusesContext.SaveChangesAsync();

            return Ok();
        }

    }
}
