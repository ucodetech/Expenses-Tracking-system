using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expenses.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIcon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatIcon",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "CatIcon",
                table: "Categories",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
