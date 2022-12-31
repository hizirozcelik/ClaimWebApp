using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClaimWebApp.Migrations
{
    /// <inheritdoc />
    public partial class statusadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ClaimRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ClaimRequests");
        }
    }
}
