using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClaimWebApp.Migrations
{
    /// <inheritdoc />
    public partial class initialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClaimRequests",
                columns: table => new
                {
                    ClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOtherExpense = table.Column<bool>(type: "bit", nullable: false),
                    OtherExpenseTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MileageTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpenseTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimRequests", x => x.ClaimId);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseClaims",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClaimRequestClaimId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseClaims", x => x.ExpenseId);
                    table.ForeignKey(
                        name: "FK_ExpenseClaims_ClaimRequests_ClaimRequestClaimId",
                        column: x => x.ClaimRequestClaimId,
                        principalTable: "ClaimRequests",
                        principalColumn: "ClaimId");
                });

            migrationBuilder.CreateTable(
                name: "MileageClaims",
                columns: table => new
                {
                    MileageClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromWhere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClaimRequestClaimId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MileageClaims", x => x.MileageClaimId);
                    table.ForeignKey(
                        name: "FK_MileageClaims_ClaimRequests_ClaimRequestClaimId",
                        column: x => x.ClaimRequestClaimId,
                        principalTable: "ClaimRequests",
                        principalColumn: "ClaimId");
                });

            migrationBuilder.CreateTable(
                name: "OtherExpenseClaims",
                columns: table => new
                {
                    OtherExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClaimRequestClaimId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherExpenseClaims", x => x.OtherExpenseId);
                    table.ForeignKey(
                        name: "FK_OtherExpenseClaims_ClaimRequests_ClaimRequestClaimId",
                        column: x => x.ClaimRequestClaimId,
                        principalTable: "ClaimRequests",
                        principalColumn: "ClaimId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseClaims_ClaimRequestClaimId",
                table: "ExpenseClaims",
                column: "ClaimRequestClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_MileageClaims_ClaimRequestClaimId",
                table: "MileageClaims",
                column: "ClaimRequestClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherExpenseClaims_ClaimRequestClaimId",
                table: "OtherExpenseClaims",
                column: "ClaimRequestClaimId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseClaims");

            migrationBuilder.DropTable(
                name: "MileageClaims");

            migrationBuilder.DropTable(
                name: "OtherExpenseClaims");

            migrationBuilder.DropTable(
                name: "ClaimRequests");
        }
    }
}
