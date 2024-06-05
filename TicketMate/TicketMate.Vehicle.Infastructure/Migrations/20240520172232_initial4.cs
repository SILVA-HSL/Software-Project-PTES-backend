using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Vehicle.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrainName",
                table: "ScheduledTrains",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainName",
                table: "ScheduledTrains");
        }
    }
}
