using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Vehicle.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class intital3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedSeatStructure_RegisteredBuses_RegisteredBusBusId",
                table: "SelectedSeatStructure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SelectedSeatStructure",
                table: "SelectedSeatStructure");

            migrationBuilder.RenameTable(
                name: "SelectedSeatStructure",
                newName: "SelectedSeatStructures");

            migrationBuilder.RenameIndex(
                name: "IX_SelectedSeatStructure_RegisteredBusBusId",
                table: "SelectedSeatStructures",
                newName: "IX_SelectedSeatStructures_RegisteredBusBusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectedSeatStructures",
                table: "SelectedSeatStructures",
                column: "Id");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_SelectedSeatStructures",
                table: "SelectedSeatStructures");

            migrationBuilder.RenameTable(
                name: "SelectedSeatStructures",
                newName: "SelectedSeatStructure");

            migrationBuilder.RenameIndex(
                name: "IX_SelectedSeatStructures_RegisteredBusBusId",
                table: "SelectedSeatStructure",
                newName: "IX_SelectedSeatStructure_RegisteredBusBusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectedSeatStructure",
                table: "SelectedSeatStructure",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedSeatStructure_RegisteredBuses_RegisteredBusBusId",
                table: "SelectedSeatStructure",
                column: "RegisteredBusBusId",
                principalTable: "RegisteredBuses",
                principalColumn: "BusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
