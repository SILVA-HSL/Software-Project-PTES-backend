using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Vehicle.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScheduleDate",
                table: "ScheduledBusDates",
                newName: "DepartureDate");

            migrationBuilder.AddColumn<string>(
                name: "ArrivalDate",
                table: "ScheduledBusDates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalDate",
                table: "ScheduledBusDates");

            migrationBuilder.RenameColumn(
                name: "DepartureDate",
                table: "ScheduledBusDates",
                newName: "ScheduleDate");
        }
    }
}
