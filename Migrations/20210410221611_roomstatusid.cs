using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.Migrations
{
    public partial class roomstatusid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomStatusId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomStatusId",
                table: "Rooms",
                column: "RoomStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomStatus_RoomStatusId",
                table: "Rooms",
                column: "RoomStatusId",
                principalTable: "RoomStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomStatus_RoomStatusId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomStatusId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomStatusId",
                table: "Rooms");
        }
    }
}
