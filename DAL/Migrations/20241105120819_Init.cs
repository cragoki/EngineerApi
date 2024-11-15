using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_engineer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_engineer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Xordinate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Yordinate = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EngineerId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_appointment_tb_engineer_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "tb_engineer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_appointment_tb_location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "tb_location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_appointment_EngineerId",
                table: "tb_appointment",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_appointment_LocationId",
                table: "tb_appointment",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_appointment");

            migrationBuilder.DropTable(
                name: "tb_engineer");

            migrationBuilder.DropTable(
                name: "tb_location");
        }
    }
}
