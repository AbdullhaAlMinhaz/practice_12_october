using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practice_12_october.Migrations
{
    /// <inheritdoc />
    public partial class Cow3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthRecord",
                columns: table => new
                {
                    H_RecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    F_Vaccine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    L_Vaccine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Treatment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Health_Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag_Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthRecord", x => x.H_RecordId);
                    table.ForeignKey(
                        name: "FK_HealthRecord_ManageCow_Tag_Number",
                        column: x => x.Tag_Number,
                        principalTable: "ManageCow",
                        principalColumn: "Tag_Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecord_Tag_Number",
                table: "HealthRecord",
                column: "Tag_Number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthRecord");
        }
    }
}
