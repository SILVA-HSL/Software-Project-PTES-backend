using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Vehicle.Domain.Models;
using TicketMate.Vehicle.Infastructure;

namespace TicketMate.Vehicle.Application.Services
{
    public class userDataSer : IuserDataSer
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public userDataSer(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<ActionResult<IEnumerable<userDataModel>>> GetUsers()
        {
            return await _vehicleDbContext.users.ToListAsync();
        }

        public async Task<ActionResult<userDataModel>> GetUser(int id)
        {
            var user = await _vehicleDbContext.users.FindAsync(id);
            if (user == null)
            {
                return new NotFoundResult();
            }
            return user;
        }

        public async Task<ActionResult<userDataModel>> GetUserByUserNameAndPassword(string userName, string password)
        {
            var user = await _vehicleDbContext.users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
            if (user == null)
            {
                return new NotFoundResult();
            }
            return user;
        }

        public async Task<ActionResult<userDataModel>> PostUser(userDataModel user)
        {
            _vehicleDbContext.users.Add(user);
            await _vehicleDbContext.SaveChangesAsync();
            return new CreatedAtActionResult(nameof(GetUser), null, new { id = user.Id }, user);
        }

        public async Task<ActionResult> PutUser(int id, userDataModel user)
        {
            if (id != user.Id)
            {
                return new BadRequestResult();
            }
            _vehicleDbContext.Entry(user).State = EntityState.Modified;
            try
            {
                await _vehicleDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return new OkResult();
        }

        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _vehicleDbContext.users.FindAsync(id);
            if (user == null)
            {
                return new NotFoundResult();
            }
            _vehicleDbContext.users.Remove(user);
            await _vehicleDbContext.SaveChangesAsync();
            return new OkResult();
        }
    }
}
