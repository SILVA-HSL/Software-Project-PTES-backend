using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Vehicle.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledLocomotives_RegisteredLocomotives_RegisteredLocomotiveLocomotiveId",
                table: "ScheduledLocomotives");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledLocomotives_ScheduledTrains_ScheduledTrainSchedulId",
                table: "ScheduledLocomotives");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledTrainDates_ScheduledTrains_ScheduledTrainSchedulId",
                table: "ScheduledTrainDates");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedTrainStations_ScheduledTrains_ScheduledTrainSchedulId",
                table: "SelectedTrainStations");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduledTrainSchedulId",
                table: "SelectedTrainStations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ScheduledTrainSchedulId",
                table: "ScheduledTrainDates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ScheduledTrainSchedulId",
                table: "ScheduledLocomotives",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RegisteredLocomotiveLocomotiveId",
                table: "ScheduledLocomotives",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LicenseImgURL",
                table: "RegisteredLocomotives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledLocomotives_RegisteredLocomotives_RegisteredLocomotiveLocomotiveId",
                table: "ScheduledLocomotives",
                column: "RegisteredLocomotiveLocomotiveId",
                principalTable: "RegisteredLocomotives",
                principalColumn: "LocomotiveId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledLocomotives_ScheduledTrains_ScheduledTrainSchedulId",
                table: "ScheduledLocomotives",
                column: "ScheduledTrainSchedulId",
                principalTable: "ScheduledTrains",
                principalColumn: "SchedulId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledTrainDates_ScheduledTrains_ScheduledTrainSchedulId",
                table: "ScheduledTrainDates",
                column: "ScheduledTrainSchedulId",
                principalTable: "ScheduledTrains",
                principalColumn: "SchedulId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedTrainStations_ScheduledTrains_ScheduledTrainSchedulId",
                table: "SelectedTrainStations",
                column: "ScheduledTrainSchedulId",
                principalTable: "ScheduledTrains",
                principalColumn: "SchedulId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledLocomotives_RegisteredLocomotives_RegisteredLocomotiveLocomotiveId",
                table: "ScheduledLocomotives");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledLocomotives_ScheduledTrains_ScheduledTrainSchedulId",
                table: "ScheduledLocomotives");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledTrainDates_ScheduledTrains_ScheduledTrainSchedulId",
                table: "ScheduledTrainDates");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedTrainStations_ScheduledTrains_ScheduledTrainSchedulId",
                table: "SelectedTrainStations");

            migrationBuilder.DropColumn(
                name: "LicenseImgURL",
                table: "RegisteredLocomotives");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduledTrainSchedulId",
                table: "SelectedTrainStations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduledTrainSchedulId",
                table: "ScheduledTrainDates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduledTrainSchedulId",
                table: "ScheduledLocomotives",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RegisteredLocomotiveLocomotiveId",
                table: "ScheduledLocomotives",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledLocomotives_RegisteredLocomotives_RegisteredLocomotiveLocomotiveId",
                table: "ScheduledLocomotives",
                column: "RegisteredLocomotiveLocomotiveId",
                principalTable: "RegisteredLocomotives",
                principalColumn: "LocomotiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledLocomotives_ScheduledTrains_ScheduledTrainSchedulId",
                table: "ScheduledLocomotives",
                column: "ScheduledTrainSchedulId",
                principalTable: "ScheduledTrains",
                principalColumn: "SchedulId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledTrainDates_ScheduledTrains_ScheduledTrainSchedulId",
                table: "ScheduledTrainDates",
                column: "ScheduledTrainSchedulId",
                principalTable: "ScheduledTrains",
                principalColumn: "SchedulId");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedTrainStations_ScheduledTrains_ScheduledTrainSchedulId",
                table: "SelectedTrainStations",
                column: "ScheduledTrainSchedulId",
                principalTable: "ScheduledTrains",
                principalColumn: "SchedulId");
        }
    }
}
