using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zavrsni_Test_Maja_Cveticanin.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zgrade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresa = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    GodinaIzgradnje = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zgrade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stanovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojStana = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipStana = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BrojKvadrata = table.Column<int>(type: "int", nullable: false),
                    CenaStana = table.Column<double>(type: "float", nullable: false),
                    ZgradaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stanovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stanovi_Zgrade_ZgradaId",
                        column: x => x.ZgradaId,
                        principalTable: "Zgrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Zgrade",
                columns: new[] { "Id", "Adresa", "GodinaIzgradnje" },
                values: new object[,]
                {
                    { 1, "Ulica Koste Racina 4", 0 },
                    { 2, "Ulica Marka Miljanova 14", 0 },
                    { 3, "Bulevar Cara Lazara 113", 0 },
                    { 4, "", 0 }
                });

            migrationBuilder.InsertData(
                table: "Stanovi",
                columns: new[] { "Id", "BrojKvadrata", "BrojStana", "CenaStana", "TipStana", "ZgradaId" },
                values: new object[,]
                {
                    { 1, 23, "001", 105000.0, "Garsonjera", 1 },
                    { 2, 43, "021", 42000.0, "Dvosoban", 2 },
                    { 3, 51, "501", 47000.0, "Dvosoban", 2 },
                    { 4, 75, "610", 180000.0, "Dvosoban", 3 },
                    { 5, 114, "610", 170000.0, "Trosoban", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stanovi_ZgradaId",
                table: "Stanovi",
                column: "ZgradaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stanovi");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Zgrade");
        }
    }
}
