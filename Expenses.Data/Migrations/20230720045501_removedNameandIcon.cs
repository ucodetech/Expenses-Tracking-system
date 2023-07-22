using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expenses.Data.Migrations
{
    /// <inheritdoc />
    public partial class removedNameandIcon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Expenses");

            migrationBuilder.AlterColumn<string>(
                name: "Descriptions",
                table: "Expenses",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldMaxLength: 200,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descriptions",
                table: "Expenses",
                type: "text",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Expenses",
                type: "nvarchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Expenses",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
