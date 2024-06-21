using Microsoft.AspNetCore.Mvc;
using TicketMate.Vehicle.Application.Services;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userDataController : ControllerBase
    {
        private readonly IuserDataSer _userDataService;

        public userDataController(IuserDataSer userDataService)
        {
            _userDataService = userDataService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<userDataModel>>> GetUsers()
        {
            return await _userDataService.GetUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<userDataModel>> GetUser(int id)
        {
            return await _userDataService.GetUser(id);
        }

        [HttpGet("authenticate")]
        public async Task<ActionResult<userDataModel>> GetUserByUserNameAndPassword([FromQuery] string userName, [FromQuery] string password)
        {
            return await _userDataService.GetUserByUserNameAndPassword(userName, password);
        }

        [HttpPost]
        public async Task<ActionResult<userDataModel>> PostUser(userDataModel user)
        {
            return await _userDataService.PostUser(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(int id, userDataModel user)
        {
            return await _userDataService.PutUser(id, user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            return await _userDataService.DeleteUser(id);
        }
    }
}
