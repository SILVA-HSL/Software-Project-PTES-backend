using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Vehicle.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusRoutes",
                columns: table => new
                {
                    RoutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoutNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartStand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndStand = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusRoutes", x => x.RoutId);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredBuses",
                columns: table => new
                {
                    BusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SetsCount = table.Column<int>(type: "int", nullable: false),
                    ACorNONAC = table.Column<bool>(type: "bit", nullable: false),
                    LicenseImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredBuses", x => x.BusId);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredCarriages",
                columns: table => new
                {
                    CarriageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarriageNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatsCount = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredCarriages", x => x.CarriageId);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredLocomotives",
                columns: table => new
                {
                    LocomotiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocomotiveNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocomotiveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocomotiveModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocomotiveCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocomotiveSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredLocomotives", x => x.LocomotiveId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledTrains",
                columns: table => new
                {
                    SchedulId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainRoutNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartStation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndStation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainDepartureTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainArrivalTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstClassTicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecondClassTicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledTrains", x => x.SchedulId);
                });

            migrationBuilder.CreateTable(
                name: "TrainRaliways",
                columns: table => new
                {
                    RailwayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RailwayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartStation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndStation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainRaliways", x => x.RailwayId);
                });

            migrationBuilder.CreateTable(
                name: "BusRouteStands",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusRouteRoutId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusRouteStands", x => x.id);
                    table.ForeignKey(
                        name: "FK_BusRouteStands_BusRoutes_BusRouteRoutId",
                        column: x => x.BusRouteRoutId,
                        principalTable: "BusRoutes",
                        principalColumn: "RoutId");
                });

            migrationBuilder.CreateTable(
                name: "ScheduledBuses",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteredBusBusId = table.Column<int>(type: "int", nullable: false),
                    BusNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    RoutNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comfortability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledBuses", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_ScheduledBuses_RegisteredBuses_RegisteredBusBusId",
                        column: x => x.RegisteredBusBusId,
                        principalTable: "RegisteredBuses",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectedSeatStructures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatAvailability = table.Column<bool>(type: "bit", nullable: false),
                    RegisteredBusBusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedSeatStructures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedSeatStructures_RegisteredBuses_RegisteredBusBusId",
                        column: x => x.RegisteredBusBusId,
                        principalTable: "RegisteredBuses",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelCarriageSeatStructures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    Avalability = table.Column<bool>(type: "bit", nullable: false),
                    RegisteredCarriageCarriageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelCarriageSeatStructures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelCarriageSeatStructures_RegisteredCarriages_RegisteredCarriageCarriageId",
                        column: x => x.RegisteredCarriageCarriageId,
                        principalTable: "RegisteredCarriages",
                        principalColumn: "CarriageId");
                });

            migrationBuilder.CreateTable(
                name: "ScheduledCarriages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledTrainSchedulId = table.Column<int>(type: "int", nullable: true),
                    RegisteredCarriageCarriageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledCarriages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledCarriages_RegisteredCarriages_RegisteredCarriageCarriageId",
                        column: x => x.RegisteredCarriageCarriageId,
                        principalTable: "RegisteredCarriages",
                        principalColumn: "CarriageId");
                    table.ForeignKey(
                        name: "FK_ScheduledCarriages_ScheduledTrains_ScheduledTrainSchedulId",
                        column: x => x.ScheduledTrainSchedulId,
                        principalTable: "ScheduledTrains",
                        principalColumn: "SchedulId");
                });

            migrationBuilder.CreateTable(
                name: "ScheduledLocomotives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduledTrainSchedulId = table.Column<int>(type: "int", nullable: true),
                    RegisteredLocomotiveLocomotiveId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledLocomotives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledLocomotives_RegisteredLocomotives_RegisteredLocomotiveLocomotiveId",
                        column: x => x.RegisteredLocomotiveLocomotiveId,
                        principalTable: "RegisteredLocomotives",
                        principalColumn: "LocomotiveId");
                    table.ForeignKey(
                        name: "FK_ScheduledLocomotives_ScheduledTrains_ScheduledTrainSchedulId",
                        column: x => x.ScheduledTrainSchedulId,
                        principalTable: "ScheduledTrains",
                        principalColumn: "SchedulId");
                });

            migrationBuilder.CreateTable(
                name: "ScheduledTrainDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledTrainSchedulId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledTrainDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledTrainDates_ScheduledTrains_ScheduledTrainSchedulId",
                        column: x => x.ScheduledTrainSchedulId,
                        principalTable: "ScheduledTrains",
                        principalColumn: "SchedulId");
                });

            migrationBuilder.CreateTable(
                name: "SelectedTrainStations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainStationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainarrivalTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainDepartureTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledTrainSchedulId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedTrainStations", x => x.id);
                    table.ForeignKey(
                        name: "FK_SelectedTrainStations_ScheduledTrains_ScheduledTrainSchedulId",
                        column: x => x.ScheduledTrainSchedulId,
                        principalTable: "ScheduledTrains",
                        principalColumn: "SchedulId");
                });

            migrationBuilder.CreateTable(
                name: "TrainRaliwayStations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainStationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainRaliwayRailwayId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainRaliwayStations", x => x.id);
                    table.ForeignKey(
                        name: "FK_TrainRaliwayStations_TrainRaliways_TrainRaliwayRailwayId",
                        column: x => x.TrainRaliwayRailwayId,
                        principalTable: "TrainRaliways",
                        principalColumn: "RailwayId");
                });

            migrationBuilder.CreateTable(
                name: "ScheduledBusDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduledBusScheduleId = table.Column<int>(type: "int", nullable: false),
                    ArrivalDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledBusDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledBusDates_ScheduledBuses_ScheduledBusScheduleId",
                        column: x => x.ScheduledBusScheduleId,
                        principalTable: "ScheduledBuses",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectedBusStands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduledBusScheduleId = table.Column<int>(type: "int", nullable: false),
                    BusStation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StandArrivalTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedBusStands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedBusStands_ScheduledBuses_ScheduledBusScheduleId",
                        column: x => x.ScheduledBusScheduleId,
                        principalTable: "ScheduledBuses",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusRouteStands_BusRouteRoutId",
                table: "BusRouteStands",
                column: "BusRouteRoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledBusDates_ScheduledBusScheduleId",
                table: "ScheduledBusDates",
                column: "ScheduledBusScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledBuses_RegisteredBusBusId",
                table: "ScheduledBuses",
                column: "RegisteredBusBusId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCarriages_RegisteredCarriageCarriageId",
                table: "ScheduledCarriages",
                column: "RegisteredCarriageCarriageId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCarriages_ScheduledTrainSchedulId",
                table: "ScheduledCarriages",
                column: "ScheduledTrainSchedulId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledLocomotives_RegisteredLocomotiveLocomotiveId",
                table: "ScheduledLocomotives",
                column: "RegisteredLocomotiveLocomotiveId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledLocomotives_ScheduledTrainSchedulId",
                table: "ScheduledLocomotives",
                column: "ScheduledTrainSchedulId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledTrainDates_ScheduledTrainSchedulId",
                table: "ScheduledTrainDates",
                column: "ScheduledTrainSchedulId");

            migrationBuilder.CreateIndex(
                name: "IX_SelCarriageSeatStructures_RegisteredCarriageCarriageId",
                table: "SelCarriageSeatStructures",
                column: "RegisteredCarriageCarriageId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedBusStands_ScheduledBusScheduleId",
                table: "SelectedBusStands",
                column: "ScheduledBusScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedSeatStructures_RegisteredBusBusId",
                table: "SelectedSeatStructures",
                column: "RegisteredBusBusId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedTrainStations_ScheduledTrainSchedulId",
                table: "SelectedTrainStations",
                column: "ScheduledTrainSchedulId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainRaliwayStations_TrainRaliwayRailwayId",
                table: "TrainRaliwayStations",
                column: "TrainRaliwayRailwayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusRouteStands");

            migrationBuilder.DropTable(
                name: "ScheduledBusDates");

            migrationBuilder.DropTable(
                name: "ScheduledCarriages");

            migrationBuilder.DropTable(
                name: "ScheduledLocomotives");

            migrationBuilder.DropTable(
                name: "ScheduledTrainDates");

            migrationBuilder.DropTable(
                name: "SelCarriageSeatStructures");

            migrationBuilder.DropTable(
                name: "SelectedBusStands");

            migrationBuilder.DropTable(
                name: "SelectedSeatStructures");

            migrationBuilder.DropTable(
                name: "SelectedTrainStations");

            migrationBuilder.DropTable(
                name: "TrainRaliwayStations");

            migrationBuilder.DropTable(
                name: "BusRoutes");

            migrationBuilder.DropTable(
                name: "RegisteredLocomotives");

            migrationBuilder.DropTable(
                name: "RegisteredCarriages");

            migrationBuilder.DropTable(
                name: "ScheduledBuses");

            migrationBuilder.DropTable(
                name: "ScheduledTrains");

            migrationBuilder.DropTable(
                name: "TrainRaliways");

            migrationBuilder.DropTable(
                name: "RegisteredBuses");
        }
    }
}
