using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Vehicle.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusRouteStands_BusRoutes_BusRouteRoutId",
                table: "BusRouteStands");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "BusRouteStands",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RegisteredBuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "BusRouteRoutId",
                table: "BusRouteStands",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

           

            migrationBuilder.AddForeignKey(
                name: "FK_BusRouteStands_BusRoutes_BusRouteRoutId",
                table: "BusRouteStands",
                column: "BusRouteRoutId",
                principalTable: "BusRoutes",
                principalColumn: "RoutId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusRouteStands_BusRoutes_BusRouteRoutId",
                table: "BusRouteStands");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RegisteredBuses");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BusRouteStands",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "BusRouteRoutId",
                table: "BusRouteStands",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BusRouteStands_BusRoutes_BusRouteRoutId",
                table: "BusRouteStands",
                column: "BusRouteRoutId",
                principalTable: "BusRoutes",
                principalColumn: "RoutId");
        }
    }
}
