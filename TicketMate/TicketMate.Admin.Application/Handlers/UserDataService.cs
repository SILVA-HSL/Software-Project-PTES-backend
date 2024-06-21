using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Admin.Domain.DTO;
using TicketMate.Admin.Domain.Models;
using TicketMate.Admin.Infastructure;

namespace TicketMate.Admin.Application.Handlers
{
    public class UserDataService
    {
        private readonly userDbContext _context;

        public UserDataService(userDbContext context)
        {
            _context = context;
        }

        public void AddUserData(AddUserDataDTO userDatas)
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
