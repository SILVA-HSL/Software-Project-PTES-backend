using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.Application.Services
{
    public interface IuserDataSer
    {
        Task<ActionResult<IEnumerable<userDataModel>>> GetUsers();
        Task<ActionResult<userDataModel>> GetUser(int id);
        Task<ActionResult<userDataModel>> GetUserByUserNameAndPassword(string userName, string password);
        Task<ActionResult<userDataModel>> PostUser(userDataModel user);
        Task<ActionResult> PutUser(int id, userDataModel user);
        Task<ActionResult> DeleteUser(int id);
    }
}
