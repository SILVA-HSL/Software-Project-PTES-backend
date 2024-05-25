using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Booking.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TicketMate.Booking.Application.Dtos;
using TicketMate.Booking.Domain.Dtos;
using TicketMate.Booking.Domain.Models;


namespace TicketMate.Booking.Infrastructure
{
    public class BookingDbContext : DbContext
    {
        public DbSet<TravelSearch> TravelSearch { get; set; }

        public DbSet<BusBooking> BusBookings { get; set; }

        public DbSet<SelectedBusStands> SelectedBusStands { get; set; }

        public DbSet<ScheduledBuses> ScheduledBuses { get; set; }

        public DbSet<ScheduledBusDates> ScheduledBusDates { get; set; }

        public DbSet<SelectedTrainStations> SelectedTrainStations { get; set; }

        public DbSet<ScheduledTrainDates> ScheduledTrainDates { get; set; }

        public DbSet<ScheduledTrains> ScheduledTrains { get; set; }

        public DbSet<BusRouteStands> BusRouteStands { get; set; }

        public DbSet<TrainRaliwayStations> TrainRaliwayStations { get; set; }

        public DbSet<RegisteredBuses> RegisteredBuses { get; set; }

        public DbSet<SelectedSeatStructures> SelectedSeatStructures { get; set; }


        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {

        }

        public BookingDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=tcp:ptesserver.database.windows.net,1433;Initial Catalog=ptescentral;Persist Security Info=False;User ID=AdminPTES;Password=PTES@admin;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(connectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ScheduledBuses>()
         .HasMany(sb => sb.SelectedBusStands)
         .WithOne(sbs => sbs.ScheduledBus)
         .HasForeignKey(sbs => sbs.ScheduledBusScheduleId);


            modelBuilder.Entity<ScheduledBusDates>()
         .HasOne(sbd => sbd.ScheduledBus)
         .WithMany(sb => sb.ScheduledBusDatesList)
         .HasForeignKey(sbd => sbd.ScheduledBusScheduleId);

        }

    }

}


