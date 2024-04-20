using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Vehicle.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class intital4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BusId",
                table: "ScheduledBuses",
                newName: "RegisteredBusBusId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledBuses_RegisteredBusBusId",
                table: "ScheduledBuses",
                column: "RegisteredBusBusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledBuses_RegisteredBuses_RegisteredBusBusId",
                table: "ScheduledBuses",
                column: "RegisteredBusBusId",
                principalTable: "RegisteredBuses",
                principalColumn: "BusId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledBuses_RegisteredBuses_RegisteredBusBusId",
                table: "ScheduledBuses");

            migrationBuilder.DropIndex(
                name: "IX_ScheduledBuses_RegisteredBusBusId",
                table: "ScheduledBuses");

            migrationBuilder.RenameColumn(
                name: "RegisteredBusBusId",
                table: "ScheduledBuses",
                newName: "BusId");
        }
    }
}
