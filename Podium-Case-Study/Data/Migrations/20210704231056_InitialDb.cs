using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Podium_Case_Study.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Dob = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterestRateType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestRateTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestRateType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MortgageProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lender = table.Column<string>(nullable: true),
                    InterestRate = table.Column<double>(nullable: false),
                    LoanToValue = table.Column<double>(nullable: false),
                    InterestRateTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MortgageProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MortgageProducts_InterestRateType_InterestRateTypeId",
                        column: x => x.InterestRateTypeId,
                        principalTable: "InterestRateType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MortgageProducts_InterestRateTypeId",
                table: "MortgageProducts",
                column: "InterestRateTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "MortgageProducts");

            migrationBuilder.DropTable(
                name: "InterestRateType");
        }
    }
}
