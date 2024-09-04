/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketMate.Admin.Infastructure;
using TicketMate.Admin.Api.Controllers;


namespace TicketMate.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  

    public class GetUserDataController : ControllerBase
    {
        public readonly userDbContext _context;
        
        public GetUserDataController(userDbContext context)
        {
            _context = context;
        }

        [HttpGet("{username?}")]
        public IActionResult GetUserData(string username)
        {
            try
            {
                if (username == null)
                {
                    return BadRequest();
                }
                else
                {
                    var userData = _context.users.Find(username);
                    return Ok(userData);
                }
            } catch(Exception e)
            {
                return BadRequest(e);    
            }
            
            

         
        }   


    }
}*/
