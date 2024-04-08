using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketMate.Admin.Domain.Models;
using TicketMate.Admin.Infastructure;
using TicketMate.Admin.Domain.DTO;

namespace TicketMate.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class userDataController : ControllerBase
    {
        private readonly userDbContext _context;

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
                DrivingLicenseNo = userDatas.DrivingLicenseNo

            };

            _context.users.Add(userData);
            _context.SaveChanges();



        }
    }
}
