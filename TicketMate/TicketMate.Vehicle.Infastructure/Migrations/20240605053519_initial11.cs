using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Vehicle.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DeleteState",
                table: "ScheduledTrains",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TrainDriverId",
                table: "ScheduledTrains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ScheduledTrains",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteState",
                table: "ScheduledTrains");

            migrationBuilder.DropColumn(
                name: "TrainDriverId",
                table: "ScheduledTrains");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ScheduledTrains");
        }
    }
}
