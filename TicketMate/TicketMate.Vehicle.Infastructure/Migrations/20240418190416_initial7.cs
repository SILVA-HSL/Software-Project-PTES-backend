using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Vehicle.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledBusDates_ScheduledBuses_ScheduledBusScheduleId",
                table: "ScheduledBusDates");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledBuses_RegisteredBuses_RegisteredBusBusId",
                table: "ScheduledBuses");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedSeatStructures_RegisteredBuses_RegisteredBusBusId",
                table: "SelectedSeatStructures");

            migrationBuilder.AlterColumn<int>(
                name: "RegisteredBusBusId",
                table: "SelectedSeatStructures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "StandArrivalTime",
                table: "SelectedBusStands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "RegisteredBusBusId",
                table: "ScheduledBuses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ScheduledBusScheduleId",
                table: "ScheduledBusDates",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledBusDates_ScheduledBuses_ScheduledBusScheduleId",
                table: "ScheduledBusDates",
                column: "ScheduledBusScheduleId",
                principalTable: "ScheduledBuses",
                principalColumn: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledBuses_RegisteredBuses_RegisteredBusBusId",
                table: "ScheduledBuses",
                column: "RegisteredBusBusId",
                principalTable: "RegisteredBuses",
                principalColumn: "BusId");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedSeatStructures_RegisteredBuses_RegisteredBusBusId",
                table: "SelectedSeatStructures",
                column: "RegisteredBusBusId",
                principalTable: "RegisteredBuses",
                principalColumn: "BusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledBusDates_ScheduledBuses_ScheduledBusScheduleId",
                table: "ScheduledBusDates");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledBuses_RegisteredBuses_RegisteredBusBusId",
                table: "ScheduledBuses");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedSeatStructures_RegisteredBuses_RegisteredBusBusId",
                table: "SelectedSeatStructures");

            migrationBuilder.DropColumn(
                name: "StandArrivalTime",
                table: "SelectedBusStands");

            migrationBuilder.AlterColumn<int>(
                name: "RegisteredBusBusId",
                table: "SelectedSeatStructures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RegisteredBusBusId",
                table: "ScheduledBuses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ScheduledBusScheduleId",
                table: "ScheduledBusDates",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledBusDates_ScheduledBuses_ScheduledBusScheduleId",
                table: "ScheduledBusDates",
                column: "ScheduledBusScheduleId",
                principalTable: "ScheduledBuses",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledBuses_RegisteredBuses_RegisteredBusBusId",
                table: "ScheduledBuses",
                column: "RegisteredBusBusId",
                principalTable: "RegisteredBuses",
                principalColumn: "BusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedSeatStructures_RegisteredBuses_RegisteredBusBusId",
                table: "SelectedSeatStructures",
                column: "RegisteredBusBusId",
                principalTable: "RegisteredBuses",
                principalColumn: "BusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
