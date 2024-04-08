using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketMate.Booking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stops",
                columns: table => new
                {
                    StopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StopName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stops", x => x.StopId);
                });

            migrationBuilder.CreateTable(
                name: "TravelSearch",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelSearch", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TravelSessions",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<double>(type: "float", nullable: false),
                    TicketPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelSessions", x => x.SessionId);
                });

            migrationBuilder.InsertData(
                table: "Stops",
                columns: new[] { "StopId", "StopName" },
                values: new object[,]
                {
                    { 1, "Colombo" },
                    { 2, "Kandy" },
                    { 3, "Nuwaraeliya" },
                    { 4, "Matara" },
                    { 5, "Galle" },
                    { 6, "Negombo" },
                    { 7, "Nawalapitiya" },
                    { 8, "Chilaw" },
                    { 9, "Anuradhapura" },
                    { 10, "Jaffna" },
                    { 11, "Batticaloa" },
                    { 12, "Trincomalee" },
                    { 13, "Kurunegala" },
                    { 14, "Gampaha" },
                    { 15, "Kegalle" },
                    { 16, "Ratnapura" },
                    { 17, "Badulla" },
                    { 18, "Monaragala" },
                    { 19, "Ampara" },
                    { 20, "Polonnaruwa" },
                    { 21, "Matale" },
                    { 22, "Vauniya" },
                    { 23, "Puttalam" },
                    { 24, "Mannar" },
                    { 25, "Kekirawa" },
                    { 26, "Mullaitivu" },
                    { 27, "Kilinochchi" },
                    { 28, "Hambanthota" },
                    { 29, "Moratuwa" },
                    { 30, "Dehiwala" }
                });

            migrationBuilder.InsertData(
                table: "TravelSessions",
                columns: new[] { "SessionId", "Duration", "EndLocation", "RegNo", "StartLocation", "TicketPrice", "TravelDate", "VehicleType" },
                values: new object[,]
                {
                    { 1, 4.5, "Kandy", "NA-1234", "Colombo", 500.0, "2024-03-20", "Bus" },
                    { 2, 3.5, "Kandy", "NA-1235", "Chilaw", 600.0, "2024-03-20", "Train" },
                    { 3, 5.5, "Chilaw", "NA-1236", "Galle", 700.0, "2024-03-20", "Bus" },
                    { 4, 6.5, "Matara", "NA-1237", "Nuwaraeliya", 800.0, "2024-03-20", "Train" },
                    { 5, 4.5, "Kandy", "NA-1238", "Colombo", 500.0, "2024-03-21", "Bus" },
                    { 6, 3.5, "Kandy", "NA-1239", "Chilaw", 600.0, "2024-03-21", "Train" },
                    { 7, 5.5, "Nawalapitiya", "NA-1240", "Negombo", 700.0, "2024-03-21", "Bus" },
                    { 8, 6.5, "Matara", "NA-1241", "Nuwaraeliya", 800.0, "2024-03-21", "Train" },
                    { 9, 4.5, "Kandy", "NA-1242", "Colombo", 500.0, "2024-03-22", "Bus" },
                    { 10, 3.5, "Kandy", "NA-1243", "Chilaw", 600.0, "2024-03-22", "Train" },
                    { 11, 3.0, "Kandy", "NB-1239", "Colombo", 800.0, "2024-03-21", "Bus" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stops");

            migrationBuilder.DropTable(
                name: "TravelSearch");

            migrationBuilder.DropTable(
                name: "TravelSessions");
        }
    }
}
