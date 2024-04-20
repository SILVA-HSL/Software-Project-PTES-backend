using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Vehicle.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class intital1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InsuranceImgURL",
                table: "RegisteredBuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LicenseImgURL",
                table: "RegisteredBuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SelectedSeatStructure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    SeatAvailability = table.Column<bool>(type: "bit", nullable: false),
                    RegisteredBusBusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedSeatStructure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedSeatStructure_RegisteredBuses_RegisteredBusBusId",
                        column: x => x.RegisteredBusBusId,
                        principalTable: "RegisteredBuses",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SelectedSeatStructure_RegisteredBusBusId",
                table: "SelectedSeatStructure",
                column: "RegisteredBusBusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelectedSeatStructure");

            migrationBuilder.DropColumn(
                name: "InsuranceImgURL",
                table: "RegisteredBuses");

            migrationBuilder.DropColumn(
                name: "LicenseImgURL",
                table: "RegisteredBuses");
        }
    }
}
