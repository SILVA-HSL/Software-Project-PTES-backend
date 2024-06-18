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

        //[Authorize(Roles = "Admin,Owner")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisteredCarriage>>> GetRegisteredCarriages()
        {
            return await _registeredCarriageService.GetRegisteredCarriages();
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisteredCarriage>> GetRegisteredCarriage(int id)
        {
            return await _registeredCarriageService.GetRegisteredCarriage(id);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpPost]
        public async Task<ActionResult<RegisteredCarriage>> PostRegisteredCarriage(RegisteredCarriage registeredCarriage)
        {
            return await _registeredCarriageService.PostRegisteredCarriage(registeredCarriage);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutRegisteredCarriage(int id, RegisteredCarriage registeredCarriage)
        {
            return await _registeredCarriageService.PutRegisteredCarriage(id, registeredCarriage);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRegisteredCarriage(int id)
        {
            return await _registeredCarriageService.DeleteRegisteredCarriage(id);
        }

        //[Authorize(Roles = "Admin,Owner")]
        // New APIs using UserId
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<RegisteredCarriage>>> GetRegisteredCarriagesByUserId(string userId)
        {
            return await _registeredCarriageService.GetRegisteredCarriagesByUserId(userId);
        }

        //[Authorize(Roles = "Admin,Owner")]
        [HttpDelete("user/{userId}")]
        public async Task<ActionResult> DeleteRegisteredCarriagesByUserId(string userId)
        {
            return await _registeredCarriageService.DeleteRegisteredCarriagesByUserId(userId);
        }
    }
}
