using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Booking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentId",
                table: "TrainBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

           

            migrationBuilder.AddColumn<string>(
                name: "PaymentId",
                table: "BusBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "TrainBookings");

           

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "BusBookings");
        }
    }
}
