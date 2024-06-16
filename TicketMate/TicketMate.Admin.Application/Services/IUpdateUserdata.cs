using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Admin.Domain.Models;

namespace TicketMate.Admin.Application.Services
{
    public interface IUpdateUserdata
    {
        public void UpdateUserData(userDataModel userDatas);
    }
}
