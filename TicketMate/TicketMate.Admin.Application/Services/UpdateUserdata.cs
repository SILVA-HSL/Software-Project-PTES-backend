using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Admin.Domain.Models;
using TicketMate.Admin.Infastructure;

namespace TicketMate.Admin.Application.Services
{
    public class UpdateUserdata: IUpdateUserdata
    {
        private readonly userDbContext _context;

        public UpdateUserdata(userDbContext context)
        {
            _context = context;
        }
        public void UpdateUserData(userDataModel userDatas)
        {
            var userdata = _context.users.Find(userDatas.Id);
            if (userdata != null)
            {
               
                userdata.FirstName = userDatas.FirstName;
                userdata.LastName = userDatas.LastName;
                userdata.Email = userDatas.Email;
                userdata.DOB = userDatas.DOB;
                userdata.NIC = userDatas.NIC;
                userdata.ContactNo = userDatas.ContactNo;
                userdata.UserName = userDatas.UserName;
                userdata.Password = userDatas.Password;
                userdata.UserType = userDatas.UserType;
                userdata.OwnVehicleType = userDatas.OwnVehicleType;
                userdata.DrivingLicenseNo = userDatas.DrivingLicenseNo;
                userdata.isDeleted = false;
                userdata.RequestStatus = true;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("User not found");
            }

            
        }
    }
}
