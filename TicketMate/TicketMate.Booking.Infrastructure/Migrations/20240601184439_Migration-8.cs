using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Booking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusBookingCancelled",
                columns: table => new
                {
                    CancelledBusBookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalBusBookingId = table.Column<int>(nullable: false),
                    BusScheduleId = table.Column<int>(nullable: false),
                    BusId = table.Column<int>(nullable: false),
                    PassengerId = table.Column<string>(nullable: false),
                    RouteNo = table.Column<string>(nullable: false),
                    StartLocation = table.Column<string>(nullable: false),
                    EndLocation = table.Column<string>(nullable: false),
                    BoardingPoint = table.Column<string>(nullable: false),
                    DroppingPoint = table.Column<string>(nullable: false),
                    StartTime = table.Column<string>(nullable: false),
                    EndTime = table.Column<string>(nullable: false),
                    BookingDate = table.Column<string>(nullable: false),
                    PaymentDate = table.Column<string>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: false),
                    BookingSeatNO = table.Column<string>(nullable: false),
                    BookingSeatCount = table.Column<string>(nullable: false),
                    TicketPrice = table.Column<decimal>(nullable: false),
                    TotalPaymentAmount = table.Column<decimal>(nullable: false),
                    PaymentStatus = table.Column<bool>(nullable: false),
                    CancellationDate = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusBookingCancelled", x => x.CancelledBusBookingId);
                });

            migrationBuilder.CreateTable(
                name: "TrainBookingCancelled",
                columns: table => new
                {
                    CancelledTrainBookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalTrainBookingId = table.Column<int>(nullable: false),
                    TrainScheduleId = table.Column<int>(nullable: false),
                    PassengerId = table.Column<string>(nullable: false),
                    RouteNo = table.Column<string>(nullable: false),
                    StartLocation = table.Column<string>(nullable: false),
                    EndLocation = table.Column<string>(nullable: false),
                    BoardingPoint = table.Column<string>(nullable: false),
                    DroppingPoint = table.Column<string>(nullable: false),
                    StartTime = table.Column<string>(nullable: false),
                    EndTime = table.Column<string>(nullable: false),
                    BookingDate = table.Column<string>(nullable: false),
                    PaymentDate = table.Column<string>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: false),
                    BookingClass = table.Column<string>(nullable: false),
                    BookingCarriageNo = table.Column<int>(nullable: false),
                    BookingSeatNO = table.Column<string>(nullable: false),
                    BookingSeatCount = table.Column<string>(nullable: false),
                    TicketPrice = table.Column<decimal>(nullable: false),
                    TotalPaymentAmount = table.Column<decimal>(nullable: false),
                    PaymentStatus = table.Column<bool>(nullable: false),
                    CancellationDate = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainBookingCancelled", x => x.CancelledTrainBookingId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusBookingCancelled");

            migrationBuilder.DropTable(
                name: "TrainBookingCancelled");
        }
    }
}
