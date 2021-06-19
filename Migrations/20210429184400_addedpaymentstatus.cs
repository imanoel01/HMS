using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.Migrations
{
    public partial class addedpaymentstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    NumberOfNightStay = table.Column<int>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    PaymentStatusId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bill_PaymentStatus_PaymentStatusId",
                        column: x => x.PaymentStatusId,
                        principalTable: "PaymentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bill_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bill_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_PaymentStatusId",
                table: "Bill",
                column: "PaymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_ReservationId",
                table: "Bill",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_RoomId",
                table: "Bill",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "PaymentStatus");
        }
    }
}
