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

namespace TicketMate.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class userDataController : ControllerBase
    {
        public readonly userDbContext _context;

        public userDataController(DbContextOptions<userDbContext> options)
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


        [HttpGet]
        public IActionResult GetUserData()
        {
            try
            {

                var userData = _context.users.Where(u => u.isDeleted == false && u.RequestStatus == true).ToList();
               // var ownerData=_context.users.Where(u => u.isDeleted == false && u.RequestStatus == false).ToList();
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
                var userData = _context.users.Find(Id);
                if (userData != null)
                {
                    userData.isDeleted=true;

                    _context.SaveChanges();
                    return Ok("User Data Updated");
                }
                return BadRequest("User Data Not Found");
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
                var userData = _context.users.Where(u => u.FirstName == firstname).ToList();
                if (userData != null)
                {
                    return Ok(userData);
                }
                return BadRequest("User Data Not Found");
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
                var userData = _context.users.Where(u => u.RequestStatus == false && u.isDeleted==false).ToList();
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
                var userData = _context.users.Find(Id);
                if (userData != null)
                {
                    userData.isDeleted = true;

                    _context.SaveChanges();
                    return Ok("rejection success");
                }
                return BadRequest("User Data Not Found");
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
                var userData = _context.users.Find(Id);
                if (userData != null)
                {
                    userData.RequestStatus = true;

                    _context.SaveChanges();
                    return Ok("acceptance success");
                }
                return BadRequest("User Data Not Found");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        
        
    }

}