using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Vehicle.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class initia2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainRaliwayStations_TrainRaliways_TrainRaliwayRailwayId",
                table: "TrainRaliwayStations");

            migrationBuilder.RenameColumn(
                name: "TrainRaliwayRailwayId",
                table: "TrainRaliwayStations",
                newName: "TrainRaliwayId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainRaliwayStations_TrainRaliwayRailwayId",
                table: "TrainRaliwayStations",
                newName: "IX_TrainRaliwayStations_TrainRaliwayId");

            migrationBuilder.RenameColumn(
                name: "RailwayId",
                table: "TrainRaliways",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "RailwayNo",
                table: "TrainRaliways",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainRaliwayStations_TrainRaliways_TrainRaliwayId",
                table: "TrainRaliwayStations",
                column: "TrainRaliwayId",
                principalTable: "TrainRaliways",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainRaliwayStations_TrainRaliways_TrainRaliwayId",
                table: "TrainRaliwayStations");

            migrationBuilder.DropColumn(
                name: "RailwayNo",
                table: "TrainRaliways");

            migrationBuilder.RenameColumn(
                name: "TrainRaliwayId",
                table: "TrainRaliwayStations",
                newName: "TrainRaliwayRailwayId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainRaliwayStations_TrainRaliwayId",
                table: "TrainRaliwayStations",
                newName: "IX_TrainRaliwayStations_TrainRaliwayRailwayId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TrainRaliways",
                newName: "RailwayId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainRaliwayStations_TrainRaliways_TrainRaliwayRailwayId",
                table: "TrainRaliwayStations",
                column: "TrainRaliwayRailwayId",
                principalTable: "TrainRaliways",
                principalColumn: "RailwayId");
        }
    }
}
