using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TicketMate.Reporting.Domain.Models;

namespace TicketMate.Reporting.Infrastructure
{
    public class ReportingDbContext : DbContext
    {
        //public DbSet<Todo> Todos { get; set; }

        public DbSet<RegisteredBus> RegisteredBuses { get; set; }
        public DbSet<BusBooking> BusBookings { get; set; }
        public DbSet<BusFeedBack> BusFeedBacks { get; set; }
        public DbSet<ScheduledTrain> ScheduledTrains { get; set; }
        public DbSet<TrainBooking> TrainBookings { get; set; }
        public DbSet<TrainFeedBack> TrainFeedBacks { get; set; }
        public DbSet<ScheduledBuses> ScheduledBuses { get; set; }
        public DbSet<ScheduledBusDate> ScheduledBusDate { get; set; }
        public DbSet<DailyBusPrediction> DailyBusPredictions { get; set; }
        public DbSet<DailyTrainPrediction> DailyTrainPredictions { get; set; }
        public DbSet<RegisteredCarriage> RegisteredCarriages { get; set; }
        public DbSet<ScheduledTrainDate> ScheduledTrainDates { get; set; }
        public DbSet<ScheduledCarriage> ScheduledCarriages { get; set; }





        public ReportingDbContext(DbContextOptions<ReportingDbContext> options) : base(options)
        {
        }
        public ReportingDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
                var connectionString = "Server=tcp:ptesserver.database.windows.net,1433;Initial Catalog=ptescentral;Persist Security Info=False;User ID=AdminPTES;Password=PTES@admin;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                optionsBuilder.UseSqlServer(connectionString);
            
        }

        
    }
}

