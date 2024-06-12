using Microsoft.EntityFrameworkCore;
using System.Xml;
using TicketMate.Payment.Domain.Model;
using TicketMate.Payment.Model;




namespace TicketMate.Payment.Data

{
    public class userDataDBContext: DbContext
    {
        public DbSet<UserDataModel> Users { get; set; }
        public DbSet<ScheduledBuses> ScheduledBuses { get; set; }
        public DbSet<ScheduledBusDates> ScheduledBusDates { get; set; }
        public DbSet<BusBookings> BusBookings { get; set; }
        public DbSet<ScheduledTrainDates> ScheduledTrainDates { get; set; }
        public DbSet<ScheduledTrains> ScheduledTrains { get; set; }
        public DbSet<TrainBookings> TrainBookings { get; set; }
        public DbSet<DriverBreakdown> DriverBreakdowns { get; set; }
        public userDataDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScheduledBuses>()
                .HasKey(sb => sb.ScheduleId);

            modelBuilder.Entity<ScheduledBusDates>()
                .HasKey(sbd => sbd.Id);

            modelBuilder.Entity<ScheduledBuses>()
                .HasMany<ScheduledBusDates>()
                .WithOne()
                .HasForeignKey(sbd => sbd.ScheduledBusScheduleId);

            modelBuilder.Entity<ScheduledBuses>()
                .Property(b => b.TicketPrice)
                .HasPrecision(18, 2); // Adjust the numbers to fit your needs
        }




    }
}

