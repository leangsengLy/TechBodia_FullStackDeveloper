using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_API_Note.Migrations
{
    /// <inheritdoc />
    public partial class updatecode1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LSNOTE",
                table: "LSNOTE");

            migrationBuilder.RenameTable(
                name: "LSNOTE",
                newName: "LSNOTEs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LSNOTEs",
                table: "LSNOTEs",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LSNOTEs",
                table: "LSNOTEs");

            migrationBuilder.RenameTable(
                name: "LSNOTEs",
                newName: "LSNOTE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LSNOTE",
                table: "LSNOTE",
                column: "ID");
        }
    }
}
