using Microsoft.EntityFrameworkCore;
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = "server = MSI; database = Vehicle; Integrated Security = True; MultipleActiveResultSets = true; MultipleActiveResultSets = true; TrustServerCertificate = True;";
            var connectionString = "Server=tcp:ticketmateserver.database.windows.net,1433;Initial Catalog=PTEScentralDb;Persist Security Info=False;User ID=adminPTES;Password=#ticket@MS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optionally configure other aspects of your model here
            modelBuilder.Entity<RegisteredBus>().HasKey(rb => rb.BusId); // Specify BusId as the primary key
            modelBuilder.Entity<ScheduledBus>().HasKey(sb => sb.ScheduleId); // Specify BusId as the primary key for ScheduledBuses

            modelBuilder.Entity<ScheduledBus>()
                .Property(b => b.TicketPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<SelectedBusStand>().HasKey(sbs => new { sbs.ScheduleId, sbs.BusStation });

            modelBuilder.Entity<SelectedBusStand>()
                .HasOne(sbs => sbs.ScheduledBus)
                .WithMany(sb => sb.SelectedBusStands)
                .HasForeignKey(sbs => new { sbs.ScheduleId })
                .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.SetNull based on your requirement

            modelBuilder.Entity<ScheduledBusDate>().HasKey(sbd => new { sbd.ScheduleId, sbd.ScheduleDate });

            modelBuilder.Entity<ScheduledBusDate>()
                .HasOne(sbd => sbd.ScheduledBus)
                .WithMany(sb => sb.ScheduledBusDates)
                .HasForeignKey(sbd => new {sbd.ScheduleId})
                .OnDelete(DeleteBehavior.Restrict);

       
        }
    }
}
