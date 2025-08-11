using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cazuela.API.Migrations
{
    /// <inheritdoc />
    public partial class Inicials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventarioMovimientos_MateriasPrimas_MateriaPrimaId",
                table: "InventarioMovimientos");

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioMovimientos_MateriasPrimas_MateriaPrimaId",
                table: "InventarioMovimientos",
                column: "MateriaPrimaId",
                principalTable: "MateriasPrimas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventarioMovimientos_MateriasPrimas_MateriaPrimaId",
                table: "InventarioMovimientos");

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioMovimientos_MateriasPrimas_MateriaPrimaId",
                table: "InventarioMovimientos",
                column: "MateriaPrimaId",
                principalTable: "MateriasPrimas",
                principalColumn: "Id");
        }
    }
}
