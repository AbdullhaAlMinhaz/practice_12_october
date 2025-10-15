using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practice_12_october.Migrations
{
    /// <inheritdoc />
    public partial class cow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "ArgentineCow",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "First_Vacine_date",
                table: "ArgentineCow",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Last_Vacine_date",
                table: "ArgentineCow",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "ArgentineCow");

            migrationBuilder.DropColumn(
                name: "First_Vacine_date",
                table: "ArgentineCow");

            migrationBuilder.DropColumn(
                name: "Last_Vacine_date",
                table: "ArgentineCow");
        }
    }
}
