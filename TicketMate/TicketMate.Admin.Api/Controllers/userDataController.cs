/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketMate.Admin.Domain.Models;
using TicketMate.Admin.Infastructure;
using TicketMate.Admin.Domain.DTO;
using TicketMate.Admin.Application.Handlers;

namespace TicketMate.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class userDataController : ControllerBase
    {
        private readonly UserDataService _userDataService;

        public userDataController(UserDataService userDataService)
        {
            _userDataService = userDataService;
        }

     


        [HttpPost]
        public void Post([FromBody] AddUserDataDTO userDatas)
        {
           _userDataService.AddUserData(userDatas);



        }
    }
}
*/

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketMate.Admin.Domain.Models;
using TicketMate.Admin.Infastructure;
using TicketMate.Admin.Domain.DTO;
using Microsoft.Extensions.Logging;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using TicketMate.Admin.Application.Services;

namespace TicketMate.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class userDataController : ControllerBase
    {
        public readonly IUserService _userService;

        public userDataController(IUserService userService)
        {
            _userService = userService;
        }       


        //public readonly userDbContext _context;

     /*   public userDataController(DbContextOptions<userDbContext> options)
        {
            _context = new userDbContext(options);

        }
     

        [HttpPost]
        public void Post([FromBody] AddUserDataDTO userDatas)
        {
            var userData = new userDataModel
            {

                FirstName = userDatas.FirstName,
                LastName = userDatas.LastName,
                Email = userDatas.Email,
                DOB = userDatas.DOB,
                NIC = userDatas.NIC,
                ContactNo = userDatas.ContactNo,
                UserName = userDatas.UserName,
                Password = userDatas.Password,
                UserType = userDatas.UserType,
                OwnVehicleType = userDatas.OwnVehicleType,
                DrivingLicenseNo = userDatas.DrivingLicenseNo,
                isDeleted = false,
                RequestStatus = true

            };

            _context.users.Add(userData);
            _context.SaveChanges();



        }

        */


        [HttpGet]
        public IActionResult GetUserData()
        {
            try
            {

               var userData = _userService.GetUserData();
                return Ok(userData);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }




        }

        [HttpPut("{Id?}")]
        public IActionResult UpdateUserData(int Id)
        {
            try
            {
                var userData = _userService.UpdateUserData(Id);
                return Ok(userData);
               
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpGet("{firstname?}")]
        public IActionResult searchUser(string firstname)
        {
            try
            {
                var userData = _userService.searchUser(firstname);
                if (userData == null)
                {
                    return NotFound("User Data Not Found");
                }
                return Ok(userData);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        
        [HttpGet("owner-requests")]
        public IActionResult GetOwnerRequests()
        {
            try
            {
                var userData = _userService.GetOwnerRequests();
                if (userData == null)
                {
                    return NotFound("Owner Data Not Found");
                }
                return Ok(userData);
               


            } catch (Exception e)
            {
               
                return BadRequest(e);
            }
        }

        

        [HttpPut("handleReject/{Id?}")]
        public IActionResult handleReject(int Id)
        {
            try
            {
               var handleReject = _userService.handleReject(Id);
                return Ok(handleReject);
                
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        

        [HttpPut("handleAccept/{Id?}")]
        public IActionResult handleAccept(int Id)
        {
            try
            {
                var handleAccept = _userService.handleAccept(Id);
                if (handleAccept == "User Data Not Found")
                {
                    return NotFound("User Data Not Found");
                }
                return Ok(handleAccept);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        
        
    }

}