using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClaimWebApp.Migrations
{
    /// <inheritdoc />
    public partial class idsChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseClaims_ClaimRequests_ClaimRequestClaimId",
                table: "ExpenseClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_MileageClaims_ClaimRequests_ClaimRequestClaimId",
                table: "MileageClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherExpenseClaims_ClaimRequests_ClaimRequestClaimId",
                table: "OtherExpenseClaims");

            migrationBuilder.RenameColumn(
                name: "ClaimRequestClaimId",
                table: "OtherExpenseClaims",
                newName: "ClaimRequestId");

            migrationBuilder.RenameColumn(
                name: "OtherExpenseId",
                table: "OtherExpenseClaims",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_OtherExpenseClaims_ClaimRequestClaimId",
                table: "OtherExpenseClaims",
                newName: "IX_OtherExpenseClaims_ClaimRequestId");

            migrationBuilder.RenameColumn(
                name: "ClaimRequestClaimId",
                table: "MileageClaims",
                newName: "ClaimRequestId");

            migrationBuilder.RenameColumn(
                name: "MileageClaimId",
                table: "MileageClaims",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_MileageClaims_ClaimRequestClaimId",
                table: "MileageClaims",
                newName: "IX_MileageClaims_ClaimRequestId");

            migrationBuilder.RenameColumn(
                name: "ClaimRequestClaimId",
                table: "ExpenseClaims",
                newName: "ClaimRequestId");

            migrationBuilder.RenameColumn(
                name: "ExpenseId",
                table: "ExpenseClaims",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseClaims_ClaimRequestClaimId",
                table: "ExpenseClaims",
                newName: "IX_ExpenseClaims_ClaimRequestId");

            migrationBuilder.RenameColumn(
                name: "ClaimId",
                table: "ClaimRequests",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseClaims_ClaimRequests_ClaimRequestId",
                table: "ExpenseClaims",
                column: "ClaimRequestId",
                principalTable: "ClaimRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MileageClaims_ClaimRequests_ClaimRequestId",
                table: "MileageClaims",
                column: "ClaimRequestId",
                principalTable: "ClaimRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherExpenseClaims_ClaimRequests_ClaimRequestId",
                table: "OtherExpenseClaims",
                column: "ClaimRequestId",
                principalTable: "ClaimRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseClaims_ClaimRequests_ClaimRequestId",
                table: "ExpenseClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_MileageClaims_ClaimRequests_ClaimRequestId",
                table: "MileageClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherExpenseClaims_ClaimRequests_ClaimRequestId",
                table: "OtherExpenseClaims");

            migrationBuilder.RenameColumn(
                name: "ClaimRequestId",
                table: "OtherExpenseClaims",
                newName: "ClaimRequestClaimId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OtherExpenseClaims",
                newName: "OtherExpenseId");

            migrationBuilder.RenameIndex(
                name: "IX_OtherExpenseClaims_ClaimRequestId",
                table: "OtherExpenseClaims",
                newName: "IX_OtherExpenseClaims_ClaimRequestClaimId");

            migrationBuilder.RenameColumn(
                name: "ClaimRequestId",
                table: "MileageClaims",
                newName: "ClaimRequestClaimId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MileageClaims",
                newName: "MileageClaimId");

            migrationBuilder.RenameIndex(
                name: "IX_MileageClaims_ClaimRequestId",
                table: "MileageClaims",
                newName: "IX_MileageClaims_ClaimRequestClaimId");

            migrationBuilder.RenameColumn(
                name: "ClaimRequestId",
                table: "ExpenseClaims",
                newName: "ClaimRequestClaimId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ExpenseClaims",
                newName: "ExpenseId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseClaims_ClaimRequestId",
                table: "ExpenseClaims",
                newName: "IX_ExpenseClaims_ClaimRequestClaimId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ClaimRequests",
                newName: "ClaimId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseClaims_ClaimRequests_ClaimRequestClaimId",
                table: "ExpenseClaims",
                column: "ClaimRequestClaimId",
                principalTable: "ClaimRequests",
                principalColumn: "ClaimId");

            migrationBuilder.AddForeignKey(
                name: "FK_MileageClaims_ClaimRequests_ClaimRequestClaimId",
                table: "MileageClaims",
                column: "ClaimRequestClaimId",
                principalTable: "ClaimRequests",
                principalColumn: "ClaimId");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherExpenseClaims_ClaimRequests_ClaimRequestClaimId",
                table: "OtherExpenseClaims",
                column: "ClaimRequestClaimId",
                principalTable: "ClaimRequests",
                principalColumn: "ClaimId");
        }
    }
}
