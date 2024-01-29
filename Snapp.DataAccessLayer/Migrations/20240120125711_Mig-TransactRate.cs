using Microsoft.EntityFrameworkCore.Migrations;

namespace Snapp.DataAccessLayer.Migrations
{
    public partial class MigTransactRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactRates_RateTypes_RateTypeId",
                table: "transactRates");

            migrationBuilder.DropForeignKey(
                name: "FK_transactRates_Transacts_TransactId",
                table: "transactRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transactRates",
                table: "transactRates");

            migrationBuilder.RenameTable(
                name: "transactRates",
                newName: "TransactRates");

            migrationBuilder.RenameIndex(
                name: "IX_transactRates_TransactId",
                table: "TransactRates",
                newName: "IX_TransactRates_TransactId");

            migrationBuilder.RenameIndex(
                name: "IX_transactRates_RateTypeId",
                table: "TransactRates",
                newName: "IX_TransactRates_RateTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactRates",
                table: "TransactRates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactRates_RateTypes_RateTypeId",
                table: "TransactRates",
                column: "RateTypeId",
                principalTable: "RateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactRates_Transacts_TransactId",
                table: "TransactRates",
                column: "TransactId",
                principalTable: "Transacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactRates_RateTypes_RateTypeId",
                table: "TransactRates");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactRates_Transacts_TransactId",
                table: "TransactRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactRates",
                table: "TransactRates");

            migrationBuilder.RenameTable(
                name: "TransactRates",
                newName: "transactRates");

            migrationBuilder.RenameIndex(
                name: "IX_TransactRates_TransactId",
                table: "transactRates",
                newName: "IX_transactRates_TransactId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactRates_RateTypeId",
                table: "transactRates",
                newName: "IX_transactRates_RateTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transactRates",
                table: "transactRates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_transactRates_RateTypes_RateTypeId",
                table: "transactRates",
                column: "RateTypeId",
                principalTable: "RateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transactRates_Transacts_TransactId",
                table: "transactRates",
                column: "TransactId",
                principalTable: "Transacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
