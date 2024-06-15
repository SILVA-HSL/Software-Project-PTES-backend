using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Admin.Application.Services;
using TicketMate.Admin.Domain.Models;

namespace TicketMate.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateProfileController : ControllerBase
    {
        public readonly IUpdateUserdata _updateUserdata;

        public UpdateProfileController(IUpdateUserdata updateUserdata)
        {
            _updateUserdata = updateUserdata;
        }

        [Authorize(Roles = "Admin,Owner,Driver,Passenger")]
        [HttpPut]
        public IActionResult updateUserProfileData( userDataModel userDatas)
        {
            try
            {
                _updateUserdata.UpdateUserData(userDatas);
                return Ok("user data updated.");
            }catch(Exception e)
            {
                return BadRequest("user data not updated."+ e);
            }
            
        }
    }
}
