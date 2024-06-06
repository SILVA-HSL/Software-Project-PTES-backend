using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Admin.Infastructure.Migrations.userDb
{
    /// <inheritdoc />
    public partial class add_requesteStatus_field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RequestStatus",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestStatus",
                table: "users");
        }
    }
}
