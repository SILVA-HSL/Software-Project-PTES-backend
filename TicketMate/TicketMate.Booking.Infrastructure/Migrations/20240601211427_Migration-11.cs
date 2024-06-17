using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Booking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusBookingCancelled");

            migrationBuilder.DropTable(
                name: "TrainBookingCancelled");

            migrationBuilder.CreateTable(
                name: "CanceledBusBooking",
                columns: table => new
                {
                    CancelledBusBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalBusBookingId = table.Column<int>(type: "int", nullable: false),
                    BusScheduleId = table.Column<int>(type: "int", nullable: false),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    PassengerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RouteNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardingPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DroppingPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingSeatNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingSeatCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentStatus = table.Column<bool>(type: "bit", nullable: false),
                    CancellationDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanceledBusBooking", x => x.CancelledBusBookingId);
                });

            migrationBuilder.CreateTable(
                name: "CanceledTrainBooking",
                columns: table => new
                {
                    CancelledTrainBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalTrainBookingId = table.Column<int>(type: "int", nullable: false),
                    TrainScheduleId = table.Column<int>(type: "int", nullable: false),
                    PassengerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RouteNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardingPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DroppingPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingCarriageNo = table.Column<int>(type: "int", nullable: false),
                    BookingSeatNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingSeatCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentStatus = table.Column<bool>(type: "bit", nullable: false),
                    CancellationDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanceledTrainBooking", x => x.CancelledTrainBookingId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "CanceledBusBookings");

            migrationBuilder.DropTable(
                name: "CanceledTrainBookings");

            migrationBuilder.CreateTable(
                name: "BusBookingCancelled",
                columns: table => new
                {
                    CancelledBusBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingSeatCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingSeatNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardingPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    BusScheduleId = table.Column<int>(type: "int", nullable: false),
                    DroppingPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalBusBookingId = table.Column<int>(type: "int", nullable: false),
                    PassengerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<bool>(type: "bit", nullable: false),
                    RouteNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusBookingCancelled", x => x.CancelledBusBookingId);
                });

            migrationBuilder.CreateTable(
                name: "TrainBookingCancelled",
                columns: table => new
                {
                    CancelledTrainBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingCarriageNo = table.Column<int>(type: "int", nullable: false),
                    BookingClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingSeatCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingSeatNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardingPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DroppingPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalTrainBookingId = table.Column<int>(type: "int", nullable: false),
                    PassengerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<bool>(type: "bit", nullable: false),
                    RouteNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainBookingCancelled", x => x.CancelledTrainBookingId);
                });
        }
        }
}
