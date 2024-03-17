using Microsoft.EntityFrameworkCore;

namespace TicketMate.Vehicle.API.Models
{
    public class RegisteredBusesContext : DbContext
    {
        public RegisteredBusesContext(DbContextOptions<RegisteredBusesContext> options) : base(options)
        {

        }

        public DbSet<RegisteredBuses> Buses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optionally configure other aspects of your model here
            modelBuilder.Entity<RegisteredBuses>().HasKey(b => b.BusId); // Specify BusId as the primary key
        }
    }
}
