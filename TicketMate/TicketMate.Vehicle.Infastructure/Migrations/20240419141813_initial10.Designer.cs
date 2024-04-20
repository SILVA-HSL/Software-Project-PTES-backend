﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketMate.Vehicle.Infastructure;

#nullable disable

namespace TicketMate.Vehicle.Infastructure.Migrations
{
    [DbContext(typeof(VehicleDbContext))]
    [Migration("20240419141813_initial10")]
    partial class initial10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.2.24128.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TicketMate.Vehicle.API.Models.RegisteredBus", b =>
                {
                    b.Property<int>("BusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusId"));

                    b.Property<bool>("ACorNONAC")
                        .HasColumnType("bit");

                    b.Property<string>("BusNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuranceImgURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenseImgURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SetsCount")
                        .HasColumnType("int");

                    b.HasKey("BusId");

                    b.ToTable("RegisteredBuses");
                });

            modelBuilder.Entity("TicketMate.Vehicle.Domain.Models.ScheduledBus", b =>
                {
                    b.Property<string>("ScheduleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ArrivalTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comfortability")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegisteredBusBusId")
                        .HasColumnType("int");

                    b.Property<string>("RoutNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TicketPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ScheduleId");

                    b.HasIndex("RegisteredBusBusId");

                    b.ToTable("ScheduledBuses");
                });

            modelBuilder.Entity("TicketMate.Vehicle.Domain.Models.ScheduledBusDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArrivalDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScheduledBusScheduleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ScheduledBusScheduleId");

                    b.ToTable("ScheduledBusDates");
                });

            modelBuilder.Entity("TicketMate.Vehicle.Domain.Models.SelectedBusStand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BusStation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScheduledBusScheduleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StandArrivalTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ScheduledBusScheduleId");

                    b.ToTable("SelectedBusStands");
                });

            modelBuilder.Entity("TicketMate.Vehicle.Domain.Models.SelectedSeatStructure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RegisteredBusBusId")
                        .HasColumnType("int");

                    b.Property<bool>("SeatAvailability")
                        .HasColumnType("bit");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegisteredBusBusId");

                    b.ToTable("SelectedSeatStructures");
                });

            modelBuilder.Entity("TicketMate.Vehicle.Domain.Models.ScheduledBus", b =>
                {
                    b.HasOne("TicketMate.Vehicle.API.Models.RegisteredBus", "RegisteredBus")
                        .WithMany("ScheduledBuses")
                        .HasForeignKey("RegisteredBusBusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RegisteredBus");
                });

            modelBuilder.Entity("TicketMate.Vehicle.Domain.Models.ScheduledBusDate", b =>
                {
                    b.HasOne("TicketMate.Vehicle.Domain.Models.ScheduledBus", "ScheduledBus")
                        .WithMany("ScheduledBusDates")
                        .HasForeignKey("ScheduledBusScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ScheduledBus");
                });

            modelBuilder.Entity("TicketMate.Vehicle.Domain.Models.SelectedBusStand", b =>
                {
                    b.HasOne("TicketMate.Vehicle.Domain.Models.ScheduledBus", "ScheduledBus")
                        .WithMany("SelectedBusStands")
                        .HasForeignKey("ScheduledBusScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ScheduledBus");
                });

            modelBuilder.Entity("TicketMate.Vehicle.Domain.Models.SelectedSeatStructure", b =>
                {
                    b.HasOne("TicketMate.Vehicle.API.Models.RegisteredBus", "RegisteredBus")
                        .WithMany("SelectedSeatStructures")
                        .HasForeignKey("RegisteredBusBusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RegisteredBus");
                });

            modelBuilder.Entity("TicketMate.Vehicle.API.Models.RegisteredBus", b =>
                {
                    b.Navigation("ScheduledBuses");

                    b.Navigation("SelectedSeatStructures");
                });

            modelBuilder.Entity("TicketMate.Vehicle.Domain.Models.ScheduledBus", b =>
                {
                    b.Navigation("ScheduledBusDates");

                    b.Navigation("SelectedBusStands");
                });
#pragma warning restore 612, 618
        }
    }
}
