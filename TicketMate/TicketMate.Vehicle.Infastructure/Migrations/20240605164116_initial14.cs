using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Vehicle.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledCarriages_RegisteredCarriages_RegisteredCarriageCarriageId",
                table: "ScheduledCarriages");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledCarriages_ScheduledTrains_ScheduledTrainSchedulId",
                table: "ScheduledCarriages");

            migrationBuilder.DropForeignKey(
                name: "FK_SelCarriageSeatStructures_RegisteredCarriages_RegisteredCarriageCarriageId",
                table: "SelCarriageSeatStructures");

            migrationBuilder.AlterColumn<int>(
                name: "RegisteredCarriageCarriageId",
                table: "SelCarriageSeatStructures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ScheduledTrainSchedulId",
                table: "ScheduledCarriages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RegisteredCarriageCarriageId",
                table: "ScheduledCarriages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledCarriages_RegisteredCarriages_RegisteredCarriageCarriageId",
                table: "ScheduledCarriages",
                column: "RegisteredCarriageCarriageId",
                principalTable: "RegisteredCarriages",
                principalColumn: "CarriageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledCarriages_ScheduledTrains_ScheduledTrainSchedulId",
                table: "ScheduledCarriages",
                column: "ScheduledTrainSchedulId",
                principalTable: "ScheduledTrains",
                principalColumn: "SchedulId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SelCarriageSeatStructures_RegisteredCarriages_RegisteredCarriageCarriageId",
                table: "SelCarriageSeatStructures",
                column: "RegisteredCarriageCarriageId",
                principalTable: "RegisteredCarriages",
                principalColumn: "CarriageId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledCarriages_RegisteredCarriages_RegisteredCarriageCarriageId",
                table: "ScheduledCarriages");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledCarriages_ScheduledTrains_ScheduledTrainSchedulId",
                table: "ScheduledCarriages");

            migrationBuilder.DropForeignKey(
                name: "FK_SelCarriageSeatStructures_RegisteredCarriages_RegisteredCarriageCarriageId",
                table: "SelCarriageSeatStructures");

            migrationBuilder.AlterColumn<int>(
                name: "RegisteredCarriageCarriageId",
                table: "SelCarriageSeatStructures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduledTrainSchedulId",
                table: "ScheduledCarriages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RegisteredCarriageCarriageId",
                table: "ScheduledCarriages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledCarriages_RegisteredCarriages_RegisteredCarriageCarriageId",
                table: "ScheduledCarriages",
                column: "RegisteredCarriageCarriageId",
                principalTable: "RegisteredCarriages",
                principalColumn: "CarriageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledCarriages_ScheduledTrains_ScheduledTrainSchedulId",
                table: "ScheduledCarriages",
                column: "ScheduledTrainSchedulId",
                principalTable: "ScheduledTrains",
                principalColumn: "SchedulId");

            migrationBuilder.AddForeignKey(
                name: "FK_SelCarriageSeatStructures_RegisteredCarriages_RegisteredCarriageCarriageId",
                table: "SelCarriageSeatStructures",
                column: "RegisteredCarriageCarriageId",
                principalTable: "RegisteredCarriages",
                principalColumn: "CarriageId");
        }
    }
}
