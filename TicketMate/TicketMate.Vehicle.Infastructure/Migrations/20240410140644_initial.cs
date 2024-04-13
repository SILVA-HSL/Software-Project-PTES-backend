using System;
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
                name: "RegisteredBuses",
                columns: table => new
                {
                    BusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SetsCount = table.Column<int>(type: "int", nullable: false),
                    ACorNONAC = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredBuses", x => x.BusId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledBuses",
                columns: table => new
                {
                    ScheduleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    BusNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    RoutNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ArrivalTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Comfortability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SelectedBusStandScheduleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SelectedBusStandBusStation = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledBuses", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "SelectedBusStands",
                columns: table => new
                {
                    ScheduleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusStation = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedBusStands", x => new { x.ScheduleId, x.BusStation });
                    table.ForeignKey(
                        name: "FK_SelectedBusStands_ScheduledBuses_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "ScheduledBuses",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledBuses_SelectedBusStandScheduleId_SelectedBusStandBusStation",
                table: "ScheduledBuses",
                columns: new[] { "SelectedBusStandScheduleId", "SelectedBusStandBusStation" });

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledBuses_SelectedBusStands_SelectedBusStandScheduleId_SelectedBusStandBusStation",
                table: "ScheduledBuses",
                columns: new[] { "SelectedBusStandScheduleId", "SelectedBusStandBusStation" },
                principalTable: "SelectedBusStands",
                principalColumns: new[] { "ScheduleId", "BusStation" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledBuses_SelectedBusStands_SelectedBusStandScheduleId_SelectedBusStandBusStation",
                table: "ScheduledBuses");

            migrationBuilder.DropTable(
                name: "RegisteredBuses");

            migrationBuilder.DropTable(
                name: "SelectedBusStands");

            migrationBuilder.DropTable(
                name: "ScheduledBuses");
        }
    }
}
