using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Vehicle.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledBusDateScheduleDate",
                table: "ScheduledBuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ScheduledBusDateScheduleId",
                table: "ScheduledBuses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ScheduledBusDates",
                columns: table => new
                {
                    ScheduleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ScheduleDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledBusDates", x => new { x.ScheduleId, x.ScheduleDate });
                    table.ForeignKey(
                        name: "FK_ScheduledBusDates_ScheduledBuses_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "ScheduledBuses",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledBuses_ScheduledBusDateScheduleId_ScheduledBusDateScheduleDate",
                table: "ScheduledBuses",
                columns: new[] { "ScheduledBusDateScheduleId", "ScheduledBusDateScheduleDate" });

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledBuses_ScheduledBusDates_ScheduledBusDateScheduleId_ScheduledBusDateScheduleDate",
                table: "ScheduledBuses",
                columns: new[] { "ScheduledBusDateScheduleId", "ScheduledBusDateScheduleDate" },
                principalTable: "ScheduledBusDates",
                principalColumns: new[] { "ScheduleId", "ScheduleDate" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledBuses_ScheduledBusDates_ScheduledBusDateScheduleId_ScheduledBusDateScheduleDate",
                table: "ScheduledBuses");

            migrationBuilder.DropTable(
                name: "ScheduledBusDates");

            migrationBuilder.DropIndex(
                name: "IX_ScheduledBuses_ScheduledBusDateScheduleId_ScheduledBusDateScheduleDate",
                table: "ScheduledBuses");

            migrationBuilder.DropColumn(
                name: "ScheduledBusDateScheduleDate",
                table: "ScheduledBuses");

            migrationBuilder.DropColumn(
                name: "ScheduledBusDateScheduleId",
                table: "ScheduledBuses");
        }
    }
}
