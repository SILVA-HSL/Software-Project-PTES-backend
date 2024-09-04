using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Booking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

           

            migrationBuilder.CreateTable(
                name: "TrainFeedBacks",
                columns: table => new
                {
                    FeedBackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainScheduleId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    PassengerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FeedBack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GivenDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainFeedBacks", x => x.FeedBackId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "TrainFeedBacks");

            
        }
    }
}
