using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RolandsAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initalcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dzivokli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numurs = table.Column<int>(type: "int", nullable: false),
                    Stavs = table.Column<int>(type: "int", nullable: false),
                    IstabuSkaits = table.Column<int>(type: "int", nullable: false),
                    IedzivotajuSkaits = table.Column<int>(type: "int", nullable: false),
                    PilnaPlatiba = table.Column<float>(type: "real", nullable: false),
                    DzivojamaPlatiba = table.Column<float>(type: "real", nullable: false),
                    MajaId = table.Column<int>(type: "int", nullable: false),
                    Secret = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dzivokli", x => x.Id);
                    table.ForeignKey(
                    name: "FK_Dzivokli_Majas_MajaId",
                    column: x => x.MajaId,
                    principalTable: "Majas",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Iedzivotaji",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vards = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uzvards = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonasKods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DzimsanasDatums = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefons = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DzivoklisId = table.Column<int>(type: "int", nullable: false),
                    IsOwner = table.Column<bool>(type: "bit", nullable: false),
                    Secret = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iedzivotaji", x => x.Id);
                    table.ForeignKey(
                    name: "FK_Iedzivotaji_Dzivokli_DzivoklisId",
                    column: x => x.DzivoklisId,
                    principalTable: "Dzivoklis",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Majas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numurs = table.Column<int>(type: "int", nullable: false),
                    Iela = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilseta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valsts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PastaIndekss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Secret = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dzivokli");

            migrationBuilder.DropTable(
                name: "Iedzivotaji");

            migrationBuilder.DropTable(
                name: "Majas");
        }
    }
}
