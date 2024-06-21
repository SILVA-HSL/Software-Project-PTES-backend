using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMate.Payment.Migrations
{
    /// <inheritdoc />
    public partial class DriverBreakDown2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           // migrationBuilder.AlterColumn<int>(
             //   name: "UserId",
               // table: "ScheduledTrains",
           //     type: "int",
             //   nullable: false,
             //   oldClrType: typeof(string),
             //   oldType: "nvarchar(max)");

//            migrationBuilder.AddColumn<int>(
  //              name: "TrainDriverId",
    //            table: "ScheduledTrains",
      //          type: "int",
        //        nullable: false,
          //      defaultValue: 0);


          //  migrationBuilder.AddColumn<int>(
           //     name: "UserId",
           //     table: "ScheduledBuses",
           //     type: "int",
           //     nullable: false,
           //     defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BusNo",
                table: "DriverBreakdowns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

           // migrationBuilder.AlterColumn<int>(
            //    name: "BusScheduleId",
             //   table: "BusBookings",
             //   type: "int",
              //  nullable: false,
              //  oldClrType: typeof(string),
              //  oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          //  migrationBuilder.DropColumn(
           //     name: "TrainDriverId",
            //    table: "ScheduledTrains");

           // migrationBuilder.DropColumn(
           //     name: "UserId",
            //    table: "ScheduledBuses");

            migrationBuilder.DropColumn(
                name: "BusNo",
                table: "DriverBreakdowns");

           // migrationBuilder.AlterColumn<string>(
           //     name: "UserId",
             //   table: "ScheduledTrains",
             //   type: "nvarchar(max)",
              //  nullable: false,
             //   oldClrType: typeof(int),
              //  oldType: "int");

          //  migrationBuilder.AlterColumn<string>(
           //     name: "BusScheduleId",
            //    table: "BusBookings",
            //    type: "nvarchar(max)",
            //    nullable: false,
             //   oldClrType: typeof(int),
             //   oldType: "int");
        }
    }
}
