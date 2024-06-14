using Microsoft.AspNetCore.Mvc;
using TicketMate.Vehicle.Application.Services;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegCarriageController : ControllerBase
    {
        private readonly IRegisteredCarriageSer _registeredCarriageService;

        public RegCarriageController(IRegisteredCarriageSer registeredCarriageService)
        {
            _registeredCarriageService = registeredCarriageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisteredCarriage>>> GetRegisteredCarriages()
        {
            return await _registeredCarriageService.GetRegisteredCarriages();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegisteredCarriage>> GetRegisteredCarriage(int id)
        {
            return await _registeredCarriageService.GetRegisteredCarriage(id);
        }

        [HttpPost]
        public async Task<ActionResult<RegisteredCarriage>> PostRegisteredCarriage(RegisteredCarriage registeredCarriage)
        {
            return await _registeredCarriageService.PostRegisteredCarriage(registeredCarriage);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutRegisteredCarriage(int id, RegisteredCarriage registeredCarriage)
        {
            return await _registeredCarriageService.PutRegisteredCarriage(id, registeredCarriage);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRegisteredCarriage(int id)
        {
            return await _registeredCarriageService.DeleteRegisteredCarriage(id);
        }

        // New APIs using UserId
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<RegisteredCarriage>>> GetRegisteredCarriagesByUserId(string userId)
        {
            return await _registeredCarriageService.GetRegisteredCarriagesByUserId(userId);
        }

        [HttpDelete("user/{userId}")]
        public async Task<ActionResult> DeleteRegisteredCarriagesByUserId(string userId)
        {
            return await _registeredCarriageService.DeleteRegisteredCarriagesByUserId(userId);
        }
    }
}
