using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_API_Note.Migrations
{
    /// <inheritdoc />
    public partial class add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LSNOTE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TITLE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CONTENT = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LSNOTE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LSUSER_LOGIN",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LSUSER_LOGIN", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LSNOTE");

            migrationBuilder.DropTable(
                name: "LSUSER_LOGIN");
        }
    }
}
