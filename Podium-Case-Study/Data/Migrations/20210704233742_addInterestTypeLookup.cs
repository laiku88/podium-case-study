using Microsoft.EntityFrameworkCore.Migrations;

namespace Podium_Case_Study.Migrations
{
    public partial class addInterestTypeLookup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MortgageProducts_InterestRateType_InterestRateTypeId",
                table: "MortgageProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterestRateType",
                table: "InterestRateType");

            migrationBuilder.RenameTable(
                name: "InterestRateType",
                newName: "InterestRateTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterestRateTypes",
                table: "InterestRateTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageProducts_InterestRateTypes_InterestRateTypeId",
                table: "MortgageProducts",
                column: "InterestRateTypeId",
                principalTable: "InterestRateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MortgageProducts_InterestRateTypes_InterestRateTypeId",
                table: "MortgageProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterestRateTypes",
                table: "InterestRateTypes");

            migrationBuilder.RenameTable(
                name: "InterestRateTypes",
                newName: "InterestRateType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterestRateType",
                table: "InterestRateType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageProducts_InterestRateType_InterestRateTypeId",
                table: "MortgageProducts",
                column: "InterestRateTypeId",
                principalTable: "InterestRateType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
