using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Admin.Domain.Models;
using TicketMate.Booking.Domain.Models;


namespace TicketMate.Admin.Infastructure
{
    public class userDbContext: DbContext
    {
        public userDbContext(DbContextOptions<userDbContext> options) : base(options)
        {
        }

        public DbSet<TicketMate.Admin.Domain.Models.userDataModel> users { get; set; }


        public DbSet<BusBooking> BusBookings { get; set; }


        public DbSet<TrainBooking> TrainBookings { get; set; }
    }
}
