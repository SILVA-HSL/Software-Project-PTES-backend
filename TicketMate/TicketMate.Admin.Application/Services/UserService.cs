using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Admin.Domain.Models;
using TicketMate.Admin.Infastructure;

namespace TicketMate.Admin.Application.Services
{
    public class UserService : IUserService
    {
       private readonly userDbContext _context;

        public UserService(userDbContext context)
        {
            _context = context;
        }


        public List<userDataModel> GetUserData()
        {
            try
            {

                var userData = _context.users.Where(u => u.isDeleted == false && u.RequestStatus == true).ToList();
                // var ownerData=_context.users.Where(u => u.isDeleted == false && u.RequestStatus == false).ToList();
                return userData;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string UpdateUserData(int Id)
        {

            try
            {
                var userData = _context.users.Find(Id);
                if (userData != null)
                {
                    userData.isDeleted = true;

                    _context.SaveChanges();
                    return ("User Data Updated");
                }
                return ("User Data Not Found");
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public List<userDataModel> searchUser(string firstname)
        {
            var userData = _context.users.Where(u => u.FirstName == firstname).ToList();
            if (userData != null)
            {
                return (userData);
            }
            return null;
        }


        public List<userDataModel> GetOwnerRequests()
        {
            var userData = _context.users.Where(u => u.RequestStatus == false && u.isDeleted == false).ToList();
            return (userData);
        }


        public string handleReject(int Id)
        {
            var userData = _context.users.Find(Id);
            if (userData != null)
            {
                userData.isDeleted = true;

                _context.SaveChanges();
                return ("rejection success");
            }
            else
            {
                return ("User Data Not Found");
            }
        }

        public string handleAccept(int Id)
        {
            var userData = _context.users.Find(Id);
            if (userData != null)
            {
                userData.RequestStatus = true;

                _context.SaveChanges();
                return ("acceptance success");
            }
            return ("User Data Not Found");
        }


        public void addUser(userDataModel userDatas)
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


    }
}
