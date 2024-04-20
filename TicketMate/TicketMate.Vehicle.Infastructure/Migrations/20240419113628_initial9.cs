using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Vehicle.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial9 : Migration
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
                name: "FK_SelectedBusStands_ScheduledBuses_ScheduledBusScheduleId",
                table: "SelectedBusStands");

            migrationBuilder.AlterColumn<string>(
                name: "ScheduledBusScheduleId",
                table: "SelectedBusStands",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
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
                name: "FK_SelectedBusStands_ScheduledBuses_ScheduledBusScheduleId",
                table: "SelectedBusStands",
                column: "ScheduledBusScheduleId",
                principalTable: "ScheduledBuses",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);
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
                name: "FK_SelectedBusStands_ScheduledBuses_ScheduledBusScheduleId",
                table: "SelectedBusStands");

            migrationBuilder.AlterColumn<string>(
                name: "ScheduledBusScheduleId",
                table: "SelectedBusStands",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
                name: "FK_SelectedBusStands_ScheduledBuses_ScheduledBusScheduleId",
                table: "SelectedBusStands",
                column: "ScheduledBusScheduleId",
                principalTable: "ScheduledBuses",
                principalColumn: "ScheduleId");
        }
    }
}
