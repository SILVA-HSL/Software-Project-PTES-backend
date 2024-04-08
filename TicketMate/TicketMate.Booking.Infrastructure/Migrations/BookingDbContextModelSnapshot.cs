﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketMate.Booking.Infrastructure;

#nullable disable

namespace TicketMate.Booking.Infrastructure.Migrations
{
    [DbContext(typeof(BookingDbContext))]
    partial class BookingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TicketMate.Booking.Api.Models.StopPoints", b =>
                {
                    b.Property<int>("StopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StopId"));

                    b.Property<string>("StopName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StopId");

                    b.ToTable("Stops");

                    b.HasData(
                        new
                        {
                            StopId = 1,
                            StopName = "Colombo"
                        },
                        new
                        {
                            StopId = 2,
                            StopName = "Kandy"
                        },
                        new
                        {
                            StopId = 3,
                            StopName = "Nuwaraeliya"
                        },
                        new
                        {
                            StopId = 4,
                            StopName = "Matara"
                        },
                        new
                        {
                            StopId = 5,
                            StopName = "Galle"
                        },
                        new
                        {
                            StopId = 6,
                            StopName = "Negombo"
                        },
                        new
                        {
                            StopId = 7,
                            StopName = "Nawalapitiya"
                        },
                        new
                        {
                            StopId = 8,
                            StopName = "Chilaw"
                        },
                        new
                        {
                            StopId = 9,
                            StopName = "Anuradhapura"
                        },
                        new
                        {
                            StopId = 10,
                            StopName = "Jaffna"
                        },
                        new
                        {
                            StopId = 11,
                            StopName = "Batticaloa"
                        },
                        new
                        {
                            StopId = 12,
                            StopName = "Trincomalee"
                        },
                        new
                        {
                            StopId = 13,
                            StopName = "Kurunegala"
                        },
                        new
                        {
                            StopId = 14,
                            StopName = "Gampaha"
                        },
                        new
                        {
                            StopId = 15,
                            StopName = "Kegalle"
                        },
                        new
                        {
                            StopId = 16,
                            StopName = "Ratnapura"
                        },
                        new
                        {
                            StopId = 17,
                            StopName = "Badulla"
                        },
                        new
                        {
                            StopId = 18,
                            StopName = "Monaragala"
                        },
                        new
                        {
                            StopId = 19,
                            StopName = "Ampara"
                        },
                        new
                        {
                            StopId = 20,
                            StopName = "Polonnaruwa"
                        },
                        new
                        {
                            StopId = 21,
                            StopName = "Matale"
                        },
                        new
                        {
                            StopId = 22,
                            StopName = "Vauniya"
                        },
                        new
                        {
                            StopId = 23,
                            StopName = "Puttalam"
                        },
                        new
                        {
                            StopId = 24,
                            StopName = "Mannar"
                        },
                        new
                        {
                            StopId = 25,
                            StopName = "Kekirawa"
                        },
                        new
                        {
                            StopId = 26,
                            StopName = "Mullaitivu"
                        },
                        new
                        {
                            StopId = 27,
                            StopName = "Kilinochchi"
                        },
                        new
                        {
                            StopId = 28,
                            StopName = "Hambanthota"
                        },
                        new
                        {
                            StopId = 29,
                            StopName = "Moratuwa"
                        },
                        new
                        {
                            StopId = 30,
                            StopName = "Dehiwala"
                        });
                });

            modelBuilder.Entity("TicketMate.Booking.Api.Models.TravelSearch", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("EndLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TravelDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("TravelSearch");
                });

            modelBuilder.Entity("TicketMate.Booking.Api.Models.TravelSessions", b =>
                {
                    b.Property<int>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SessionId"));

                    b.Property<double>("Duration")
                        .HasColumnType("float");

                    b.Property<string>("EndLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TicketPrice")
                        .HasColumnType("float");

                    b.Property<string>("TravelDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SessionId");

                    b.ToTable("TravelSessions");

                    b.HasData(
                        new
                        {
                            SessionId = 1,
                            Duration = 4.5,
                            EndLocation = "Kandy",
                            RegNo = "NA-1234",
                            StartLocation = "Colombo",
                            TicketPrice = 500.0,
                            TravelDate = "2024-03-20",
                            VehicleType = "Bus"
                        },
                        new
                        {
                            SessionId = 2,
                            Duration = 3.5,
                            EndLocation = "Kandy",
                            RegNo = "NA-1235",
                            StartLocation = "Chilaw",
                            TicketPrice = 600.0,
                            TravelDate = "2024-03-20",
                            VehicleType = "Train"
                        },
                        new
                        {
                            SessionId = 3,
                            Duration = 5.5,
                            EndLocation = "Chilaw",
                            RegNo = "NA-1236",
                            StartLocation = "Galle",
                            TicketPrice = 700.0,
                            TravelDate = "2024-03-20",
                            VehicleType = "Bus"
                        },
                        new
                        {
                            SessionId = 4,
                            Duration = 6.5,
                            EndLocation = "Matara",
                            RegNo = "NA-1237",
                            StartLocation = "Nuwaraeliya",
                            TicketPrice = 800.0,
                            TravelDate = "2024-03-20",
                            VehicleType = "Train"
                        },
                        new
                        {
                            SessionId = 5,
                            Duration = 4.5,
                            EndLocation = "Kandy",
                            RegNo = "NA-1238",
                            StartLocation = "Colombo",
                            TicketPrice = 500.0,
                            TravelDate = "2024-03-21",
                            VehicleType = "Bus"
                        },
                        new
                        {
                            SessionId = 6,
                            Duration = 3.5,
                            EndLocation = "Kandy",
                            RegNo = "NA-1239",
                            StartLocation = "Chilaw",
                            TicketPrice = 600.0,
                            TravelDate = "2024-03-21",
                            VehicleType = "Train"
                        },
                        new
                        {
                            SessionId = 7,
                            Duration = 5.5,
                            EndLocation = "Nawalapitiya",
                            RegNo = "NA-1240",
                            StartLocation = "Negombo",
                            TicketPrice = 700.0,
                            TravelDate = "2024-03-21",
                            VehicleType = "Bus"
                        },
                        new
                        {
                            SessionId = 8,
                            Duration = 6.5,
                            EndLocation = "Matara",
                            RegNo = "NA-1241",
                            StartLocation = "Nuwaraeliya",
                            TicketPrice = 800.0,
                            TravelDate = "2024-03-21",
                            VehicleType = "Train"
                        },
                        new
                        {
                            SessionId = 9,
                            Duration = 4.5,
                            EndLocation = "Kandy",
                            RegNo = "NA-1242",
                            StartLocation = "Colombo",
                            TicketPrice = 500.0,
                            TravelDate = "2024-03-22",
                            VehicleType = "Bus"
                        },
                        new
                        {
                            SessionId = 10,
                            Duration = 3.5,
                            EndLocation = "Kandy",
                            RegNo = "NA-1243",
                            StartLocation = "Chilaw",
                            TicketPrice = 600.0,
                            TravelDate = "2024-03-22",
                            VehicleType = "Train"
                        },
                        new
                        {
                            SessionId = 11,
                            Duration = 3.0,
                            EndLocation = "Kandy",
                            RegNo = "NB-1239",
                            StartLocation = "Colombo",
                            TicketPrice = 800.0,
                            TravelDate = "2024-03-21",
                            VehicleType = "Bus"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
