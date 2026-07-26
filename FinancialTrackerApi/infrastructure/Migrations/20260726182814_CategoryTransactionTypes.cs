using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialTrackerApi.Migrations
{
    /// <inheritdoc />
    public partial class CategoryTransactionTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionTypeId",
                table: "Categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionTypeId",
                table: "Categories");
        }
    }
}
