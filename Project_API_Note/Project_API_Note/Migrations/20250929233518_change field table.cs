using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_API_Note.Migrations
{
    /// <inheritdoc />
    public partial class changefieldtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LSNOTEs",
                table: "LSNOTEs");

            migrationBuilder.RenameTable(
                name: "LSNOTEs",
                newName: "LSNOTE");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "LSNOTE",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LSNOTE",
                table: "LSNOTE",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LSNOTE",
                table: "LSNOTE");

            migrationBuilder.RenameTable(
                name: "LSNOTE",
                newName: "LSNOTEs");

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                table: "LSNOTEs",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LSNOTEs",
                table: "LSNOTEs",
                column: "ID");
        }
    }
}
