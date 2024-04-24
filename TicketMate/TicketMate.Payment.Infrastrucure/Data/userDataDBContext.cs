using Microsoft.EntityFrameworkCore;
using System.Xml;
using TicketMate.Payment.Model;
//using TicketMate.Admin.Domain.Models;

namespace TicketMate.Payment.Data
{
    public class UserDataDBContext: DbContext
    {
        public DbSet<UserDataModel> Users { get; set; }
        //public DbSet<userDataModel> users { get; set; }

        public UserDataDBContext(DbContextOptions dbContextOptions): base(dbContextOptions)       
        {
            
        }
    }
}
