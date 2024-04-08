using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Booking.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;


namespace TicketMate.Booking.Infrastructure
{
    public class BookingDbContext : DbContext
    {
        public DbSet<TravelSearch> TravelSearch { get; set; }
        public DbSet<StopPoints> Stops { get; set; }
        public DbSet<TravelSessions> TravelSessions { get; set; }


        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {

        }

       public BookingDbContext()
        {

        }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=tcp:ticketmateserver.database.windows.net,1433;Initial Catalog=PTEScentralDb;Persist Security Info=False;User ID=adminPTES;Password=#ticket@MS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";
            optionsBuilder.UseSqlServer(connectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<StopPoints>().HasData(
                new StopPoints
                {
                    StopId = 1,
                    StopName = "Colombo"
                },
                new StopPoints
                {
                    StopId = 2,
                    StopName = "Kandy"
                },
                new StopPoints
                {
                    StopId = 3,
                    StopName = "Nuwaraeliya"
                },
                new StopPoints
                {
                    StopId = 4,
                    StopName = "Matara"
                },
                    new StopPoints
                    {
                        StopId = 5,
                        StopName = "Galle"
                    },
                    new StopPoints
                    {
                        StopId = 6,
                        StopName = "Negombo"
                    },
                    new StopPoints
                    {
                        StopId = 7,
                        StopName = "Nawalapitiya"
                    },
                    new StopPoints
                    {
                        StopId = 8,
                        StopName = "Chilaw"
                    },
                    new StopPoints
                    {
                        StopId = 9,
                        StopName = "Anuradhapura"
                    },
                    new StopPoints
                    {
                        StopId = 10,
                        StopName = "Jaffna"
                    },
                    new StopPoints
                    {
                        StopId = 11,
                        StopName = "Batticaloa"
                    },
                    new StopPoints
                    {
                        StopId = 12,
                        StopName = "Trincomalee"
                    },
                    new StopPoints
                    {
                        StopId = 13,
                        StopName = "Kurunegala"
                    },
                    new StopPoints
                    {
                        StopId = 14,
                        StopName = "Gampaha"
                    },
                    new StopPoints
                    {
                        StopId = 15,
                        StopName = "Kegalle"
                    },
                    new StopPoints
                    {
                        StopId = 16,
                        StopName = "Ratnapura"
                    },
                    new StopPoints
                    {
                        StopId = 17,
                        StopName = "Badulla"
                    },
                    new StopPoints
                    {
                        StopId = 18,
                        StopName = "Monaragala"
                    },
                    new StopPoints
                    {
                        StopId = 19,
                        StopName = "Ampara"
                    },
                    new StopPoints
                    {
                        StopId = 20,
                        StopName = "Polonnaruwa"
                    },
                    new StopPoints
                    {
                        StopId = 21,
                        StopName = "Matale"
                    },
                    new StopPoints
                    {
                        StopId = 22,
                        StopName = "Vauniya"
                    },
                    new StopPoints
                    {
                        StopId = 23,
                        StopName = "Puttalam"
                    },
                    new StopPoints
                    {
                        StopId = 24,
                        StopName = "Mannar"
                    },
                    new StopPoints
                    {
                        StopId = 25,
                        StopName = "Kekirawa"
                    },
                    new StopPoints
                    {
                        StopId = 26,
                        StopName = "Mullaitivu"
                    },
                    new StopPoints
                    {
                        StopId = 27,
                        StopName = "Kilinochchi"
                    },
                    new StopPoints
                    {
                        StopId = 28,
                        StopName = "Hambanthota"
                    },
                    new StopPoints
                    {
                        StopId = 29,
                        StopName = "Moratuwa"
                    },
                    new StopPoints
                    {
                        StopId = 30,
                        StopName = "Dehiwala"
                    }

                );

            modelBuilder.Entity<TravelSessions>().HasData(
               new TravelSessions
               {
                   SessionId = 1,
                   VehicleType = "Bus",
                   StartLocation = "Colombo",
                   EndLocation = "Kandy",
                   TravelDate = "2024-03-20",
                   RegNo = "NA-1234",
                   Duration = 4.5,
                   TicketPrice = 500.00
               },
               new TravelSessions
               {
                   SessionId = 2,
                   VehicleType = "Train",
                   StartLocation = "Chilaw",
                   EndLocation = "Kandy",
                   TravelDate = "2024-03-20",
                   RegNo = "NA-1235",
                   Duration = 3.5,
                   TicketPrice = 600.00
               },
               new TravelSessions
               {
                   SessionId = 3,
                   VehicleType = "Bus",
                   StartLocation = "Galle",
                   EndLocation = "Chilaw",
                   TravelDate = "2024-03-20",
                   RegNo = "NA-1236",
                   Duration = 5.5,
                   TicketPrice = 700.00
               },
               new TravelSessions
               {
                   SessionId = 4,
                   VehicleType = "Train",
                   StartLocation = "Nuwaraeliya",
                   EndLocation = "Matara",
                   TravelDate = "2024-03-20",
                   RegNo = "NA-1237",
                   Duration = 6.5,
                   TicketPrice = 800.00
               },
               new TravelSessions
               {
                   SessionId = 5,
                   VehicleType = "Bus",
                   StartLocation = "Colombo",
                   EndLocation = "Kandy",
                   TravelDate = "2024-03-21",
                   RegNo = "NA-1238",
                   Duration = 4.5,
                   TicketPrice = 500.00
               },
               new TravelSessions
               {
                   SessionId = 6,
                   VehicleType = "Train",
                   StartLocation = "Chilaw",
                   EndLocation = "Kandy",
                   TravelDate = "2024-03-21",
                   RegNo = "NA-1239",
                   Duration = 3.5,
                   TicketPrice = 600.00
               },
               new TravelSessions
               {
                   SessionId = 7,
                   VehicleType = "Bus",
                   StartLocation = "Negombo",
                   EndLocation = "Nawalapitiya",
                   TravelDate = "2024-03-21",
                   RegNo = "NA-1240",
                   Duration = 5.5,
                   TicketPrice = 700.00
               },
               new TravelSessions
               {
                   SessionId = 8,
                   VehicleType = "Train",
                   StartLocation = "Nuwaraeliya",
                   EndLocation = "Matara",
                   TravelDate = "2024-03-21",
                   RegNo = "NA-1241",
                   Duration = 6.5,
                   TicketPrice = 800.00
               },
               new TravelSessions
               {
                   SessionId = 9,
                   VehicleType = "Bus",
                   StartLocation = "Colombo",
                   EndLocation = "Kandy",
                   TravelDate = "2024-03-22",
                   RegNo = "NA-1242",
                   Duration = 4.5,
                   TicketPrice = 500.00
               },
               new TravelSessions
               {
                   SessionId = 10,
                   VehicleType = "Train",
                   StartLocation = "Chilaw",
                   EndLocation = "Kandy",
                   TravelDate = "2024-03-22",
                   RegNo = "NA-1243",
                   Duration = 3.5,
                   TicketPrice = 600.00
               },
                new TravelSessions
                {
                    SessionId = 11,
                    VehicleType = "Bus",
                    StartLocation = "Colombo",
                    EndLocation = "Kandy",
                    TravelDate = "2024-03-21",
                    RegNo = "NB-1239",
                    Duration = 3,
                    TicketPrice = 800.00
                }



               );










        }

    }
}
