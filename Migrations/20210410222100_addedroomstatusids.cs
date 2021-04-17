using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.Migrations
{
    public partial class addedroomstatusids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Rooms");
        }
    }
}
