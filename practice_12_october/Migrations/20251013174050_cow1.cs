using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practice_12_october.Migrations
{
    /// <inheritdoc />
    public partial class cow1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "ArgentineCow",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "color",
                table: "ArgentineCow");
        }
    }
}
