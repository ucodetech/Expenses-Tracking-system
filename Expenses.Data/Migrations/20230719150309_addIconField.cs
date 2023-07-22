using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expenses.Data.Migrations
{
    /// <inheritdoc />
    public partial class addIconField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Expenses",
                type: "nvarchar(200)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Expenses");
        }
    }
}
