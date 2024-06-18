using Microsoft.AspNetCore.Mvc;
using TicketMate.Vehicle.Application.Services;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegLocomotiveController : ControllerBase
    {
        private readonly IRegisteredLocomotiveSer _registeredLocomotiveService;

        public RegLocomotiveController(IRegisteredLocomotiveSer registeredLocomotiveService)
        {
            _registeredLocomotiveService = registeredLocomotiveService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisteredLocomotive>>> GetRegisteredLocomotives()
        {
            return await _registeredLocomotiveService.GetRegisteredLocomotives();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegisteredLocomotive>> GetRegisteredLocomotive(int id)
        {
            return await _registeredLocomotiveService.GetRegisteredLocomotive(id);
        }

        [HttpPost]
        public async Task<ActionResult<RegisteredLocomotive>> PostRegisteredLocomotive(RegisteredLocomotive locomotiveRegistration)
        {
            return await _registeredLocomotiveService.PostRegisteredLocomotive(locomotiveRegistration);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutRegisteredLocomotive(int id, RegisteredLocomotive locomotiveRegistration)
        {
            return await _registeredLocomotiveService.PutRegisteredLocomotive(id, locomotiveRegistration);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRegisteredLocomotive(int id)
        {
            return await _registeredLocomotiveService.DeleteRegisteredLocomotive(id);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<RegisteredLocomotive>>> GetRegisteredLocomotivesByUserId(string userId)
        {
            return await _registeredLocomotiveService.GetRegisteredLocomotivesByUserId(userId);
        }
    }
}
