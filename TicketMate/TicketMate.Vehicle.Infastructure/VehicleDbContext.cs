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
        public DbSet<ScheduledBusDate> ScheduledBusDates { get; set; }
        public DbSet<SelectedSeatStructure> SelectedSeatStructures { get; set; }
        public DbSet<RegisteredLocomotive> RegisteredLocomotives { get; set; }
        public DbSet<RegisteredCarriage> RegisteredCarriages { get; set; }
        public DbSet<ScheduledTrain> ScheduledTrains { get; set; }
        public DbSet<ScheduledCarriage> ScheduledCarriages { get; set; }
        public DbSet<ScheduledLocomotive> ScheduledLocomotives { get; set; }
        public DbSet<ScheduledTrainDate> ScheduledTrainDates { get; set; }
        public DbSet<SelCarriageSeatStructure> SelCarriageSeatStructures { get; set; }
        public DbSet<BusRoute> BusRoutes { get; set; }
        public DbSet<BusRouteStand> BusRouteStands { get; set; }
        public DbSet<TrainRaliway> TrainRaliways { get; set; }
        public DbSet<TrainRaliwayStation> TrainRaliwayStations { get; set; }
        public DbSet<SelectedTrainStation> SelectedTrainStations { get; set; }
        public DbSet<userDataModel> users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = "server = MSI; database = Vehicle; Integrated Security = True; MultipleActiveResultSets = true; MultipleActiveResultSets = true; TrustServerCertificate = True;";
            //var connectionString = "Server=tcp:ticketmateserver.database.windows.net,1433;Initial Catalog=PTEScentralDb;Persist Security Info=False;User ID=adminPTES;Password=#ticket@MS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";
            var connectionString = "Server=tcp:ptesserver.database.windows.net,1433;Initial Catalog=ptescentral;Persist Security Info=False;User ID=AdminPTES;Password=PTES@admin;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScheduledBus>()
               .Property(b => b.TicketPrice)
               .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ScheduledTrain>()
                .Property(b => b.FirstClassTicketPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ScheduledTrain>()
                .Property(b => b.SecondClassTicketPrice)
                .HasColumnType("decimal(18,2)");
        }

    }
}
