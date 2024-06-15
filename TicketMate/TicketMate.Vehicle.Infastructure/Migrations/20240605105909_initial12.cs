using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Vehicle.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DeleteState",
                table: "RegisteredLocomotives",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RegisteredLocomotives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteState",
                table: "RegisteredLocomotives");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RegisteredLocomotives");
        }
    }
}
