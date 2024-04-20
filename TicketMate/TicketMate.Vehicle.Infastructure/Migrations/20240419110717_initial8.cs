using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Vehicle.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedSeatStructures_RegisteredBuses_RegisteredBusBusId",
                table: "SelectedSeatStructures");

            migrationBuilder.AlterColumn<int>(
                name: "RegisteredBusBusId",
                table: "SelectedSeatStructures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedSeatStructures_RegisteredBuses_RegisteredBusBusId",
                table: "SelectedSeatStructures",
                column: "RegisteredBusBusId",
                principalTable: "RegisteredBuses",
                principalColumn: "BusId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedSeatStructures_RegisteredBuses_RegisteredBusBusId",
                table: "SelectedSeatStructures",
                column: "RegisteredBusBusId",
                principalTable: "RegisteredBuses",
                principalColumn: "BusId");
        }
    }
}
