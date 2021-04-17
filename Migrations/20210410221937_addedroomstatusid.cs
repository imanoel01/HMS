using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.Migrations
{
    public partial class addedroomstatusid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomStatus_RoomStatusId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "RoomStatusId",
                table: "Rooms",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomStatus_RoomStatusId",
                table: "Rooms",
                column: "RoomStatusId",
                principalTable: "RoomStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomStatus_RoomStatusId",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "RoomStatusId",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomStatus_RoomStatusId",
                table: "Rooms",
                column: "RoomStatusId",
                principalTable: "RoomStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
