using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Booking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancelledBusBookings");

            migrationBuilder.DropTable(
                name: "CancelledTrainBookings");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
