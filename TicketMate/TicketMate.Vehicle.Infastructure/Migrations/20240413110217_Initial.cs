using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Vehicle.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    DepartureTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comfortability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledBuses", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledBusDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledBusScheduleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    BusStation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledBusScheduleId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                name: "IX_ScheduledBusDates_ScheduledBusScheduleId",
                table: "ScheduledBusDates",
                column: "ScheduledBusScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedBusStands_ScheduledBusScheduleId",
                table: "SelectedBusStands",
                column: "ScheduledBusScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisteredBuses");

            migrationBuilder.DropTable(
                name: "ScheduledBusDates");

            migrationBuilder.DropTable(
                name: "SelectedBusStands");

            migrationBuilder.DropTable(
                name: "ScheduledBuses");
        }
    }
}
