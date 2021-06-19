using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.Migrations
{
    public partial class modifiedbillsandrooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Rooms_RoomId",
                table: "Bill");

            migrationBuilder.DropIndex(
                name: "IX_Bill_RoomId",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Bill");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Bill",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bill_RoomId",
                table: "Bill",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Rooms_RoomId",
                table: "Bill",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
