using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_API_Note.Migrations
{
    /// <inheritdoc />
    public partial class changetoupper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "LSNOTEs",
                newName: "TITLE");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "LSNOTEs",
                newName: "CONTENT");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "LSNOTEs",
                newName: "UPDATED_AT");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "LSNOTEs",
                newName: "CREATED_AT");

            migrationBuilder.AlterColumn<string>(
                name: "TITLE",
                table: "LSNOTEs",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CONTENT",
                table: "LSNOTEs",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TITLE",
                table: "LSNOTEs",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "CONTENT",
                table: "LSNOTEs",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "UPDATED_AT",
                table: "LSNOTEs",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CREATED_AT",
                table: "LSNOTEs",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "LSNOTEs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "LSNOTEs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);
        }
    }
}
