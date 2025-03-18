using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CliffhangerPoint.Migrations
{
    /// <inheritdoc />
    public partial class EditingMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                schema: "dbo",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                schema: "dbo",
                table: "Movies",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                schema: "dbo",
                table: "Movies");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                schema: "dbo",
                table: "Movies",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
