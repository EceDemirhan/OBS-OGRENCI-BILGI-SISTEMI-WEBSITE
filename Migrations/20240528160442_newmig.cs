using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication21.Migrations
{
    public partial class newmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DersProgramics");

            migrationBuilder.CreateTable(
                name: "Ders_Programi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DerslerId = table.Column<int>(type: "int", nullable: false),
                    DersId = table.Column<int>(type: "int", nullable: false),
                    OgretmenId = table.Column<int>(type: "int", nullable: false),
                    OgrId = table.Column<int>(type: "int", nullable: false),
                    tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ders_Programi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ders_Programi_Dersler_DerslerId",
                        column: x => x.DerslerId,
                        principalTable: "Dersler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ders_Programi_Ogretmenler_OgretmenId",
                        column: x => x.OgretmenId,
                        principalTable: "Ogretmenler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ders_Programi_DerslerId",
                table: "Ders_Programi",
                column: "DerslerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ders_Programi_OgretmenId",
                table: "Ders_Programi",
                column: "OgretmenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ders_Programi");

            migrationBuilder.CreateTable(
                name: "DersProgramics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DerslerId = table.Column<int>(type: "int", nullable: false),
                    OgretmenId = table.Column<int>(type: "int", nullable: false),
                    DersId = table.Column<int>(type: "int", nullable: false),
                    OgrId = table.Column<int>(type: "int", nullable: false),
                    tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersProgramics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DersProgramics_Dersler_DerslerId",
                        column: x => x.DerslerId,
                        principalTable: "Dersler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DersProgramics_Ogretmenler_OgretmenId",
                        column: x => x.OgretmenId,
                        principalTable: "Ogretmenler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DersProgramics_DerslerId",
                table: "DersProgramics",
                column: "DerslerId");

            migrationBuilder.CreateIndex(
                name: "IX_DersProgramics_OgretmenId",
                table: "DersProgramics",
                column: "OgretmenId");
        }
    }
}
