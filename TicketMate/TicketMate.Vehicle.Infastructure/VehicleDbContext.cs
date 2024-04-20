using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Vehicle.API.Models;
using TicketMate.Vehicle.Domain.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TicketMate.Vehicle.Infastructure
{
    public class VehicleDbContext : DbContext
    {
        public DbSet<SelectedBusStand> SelectedBusStands { get; set; }
        public DbSet<RegisteredBus> RegisteredBuses { get; set; }
        public DbSet<ScheduledBus> ScheduledBuses { get; set; }
        public DbSet<ScheduledBusDate> ScheduledBusDates {  get; set; }
        public DbSet<SelectedSeatStructure> SelectedSeatStructures { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = "server = MSI; database = Vehicle; Integrated Security = True; MultipleActiveResultSets = true; MultipleActiveResultSets = true; TrustServerCertificate = True;";
            var connectionString = "Server=tcp:ticketmateserver.database.windows.net,1433;Initial Catalog=PTEScentralDb;Persist Security Info=False;User ID=adminPTES;Password=#ticket@MS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScheduledBus>()
               .Property(b => b.TicketPrice)
               .HasColumnType("decimal(18,2)");

        }

    }
}
