using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Booking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "TrainBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

          
            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "BusBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "TrainBookings");

            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "BusBookings");

        }
    }
}
