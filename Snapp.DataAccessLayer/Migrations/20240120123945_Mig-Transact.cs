using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Snapp.DataAccessLayer.Migrations
{
    public partial class MigTransact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    EndTime = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fee = table.Column<long>(type: "bigint", nullable: false),
                    Discount = table.Column<long>(type: "bigint", nullable: false),
                    Total = table.Column<long>(type: "bigint", nullable: false),
                    IsCash = table.Column<bool>(type: "bit", nullable: false),
                    StartAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartLat = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StartLng = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EndAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndLat = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EndLng = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    DriverRate = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transactRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RateTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactRates_RateTypes_RateTypeId",
                        column: x => x.RateTypeId,
                        principalTable: "RateTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transactRates_Transacts_TransactId",
                        column: x => x.TransactId,
                        principalTable: "Transacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transactRates_RateTypeId",
                table: "transactRates",
                column: "RateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_transactRates_TransactId",
                table: "transactRates",
                column: "TransactId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacts_UserId",
                table: "Transacts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactRates");

            migrationBuilder.DropTable(
                name: "Transacts");
        }
    }
}
