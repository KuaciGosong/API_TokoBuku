using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_TokoBuku.Migrations
{
    /// <inheritdoc />
    public partial class DB_TokoBuku : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bukus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Judul_Buku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Penulis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Harga_Satuan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bukus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pelanggans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama_Pelanggan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelanggans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pembelians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jumlah_Beli = table.Column<int>(type: "int", nullable: false),
                    Tanggal_Pembelian = table.Column<DateOnly>(type: "date", nullable: false),
                    BukuID = table.Column<int>(type: "int", nullable: false),
                    PelangganID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pembelians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pembelians_Bukus_BukuID",
                        column: x => x.BukuID,
                        principalTable: "Bukus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pembelians_Pelanggans_PelangganID",
                        column: x => x.PelangganID,
                        principalTable: "Pelanggans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pembelians_BukuID",
                table: "Pembelians",
                column: "BukuID");

            migrationBuilder.CreateIndex(
                name: "IX_Pembelians_PelangganID",
                table: "Pembelians",
                column: "PelangganID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pembelians");

            migrationBuilder.DropTable(
                name: "Bukus");

            migrationBuilder.DropTable(
                name: "Pelanggans");
        }
    }
}
