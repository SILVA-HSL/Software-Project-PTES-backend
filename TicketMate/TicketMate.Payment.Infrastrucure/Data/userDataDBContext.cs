using Microsoft.EntityFrameworkCore;
using System.Xml;
using TicketMate.Payment.Model;

namespace TicketMate.Payment.Data
{
    public class UserDataDBContext: DbContext
    {
        public DbSet<UserDataModel> Users { get; set; }

        public UserDataDBContext(DbContextOptions dbContextOptions): base(dbContextOptions)       
        {
            
        }
    }
}
