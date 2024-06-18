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
    public interface IUserService
    {




        public List<userDataModel> GetUserData();
        public string UpdateUserData(int Id);

        public List<userDataModel> searchUser(string firstname);
        public List<userDataModel> GetOwnerRequests();
        public string handleReject(int Id);
        public string handleAccept(int Id);
        public void addUser(userDataModel userDatas);
        public List<userDataModel> findUser(string username, string password);



    }
}
