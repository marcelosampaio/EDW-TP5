using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EDW_TP5.Migrations
{
    /// <inheritdoc />
    public partial class SeedPontosDeVendaEProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PontosDeVenda",
                columns: new[] { "PontoDeVendaId", "EventoId", "Nome" },
                values: new object[,]
                {
                    { 1, 1, "Barraca do Cachorro Quente" },
                    { 2, 1, "Barraca de Bebidas" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "ProdutoId", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, "Cachorro-quente", 10.00m },
                    { 2, "Refrigerante", 8.00m },
                    { 3, "Água", 6.00m },
                    { 4, "Cerveja", 8.00m }
                });

            migrationBuilder.InsertData(
                table: "PontoDeVendaProduto",
                columns: new[] { "PontoDeVendaId", "ProdutoId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PontoDeVendaProduto",
                keyColumns: new[] { "PontoDeVendaId", "ProdutoId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PontoDeVendaProduto",
                keyColumns: new[] { "PontoDeVendaId", "ProdutoId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PontoDeVendaProduto",
                keyColumns: new[] { "PontoDeVendaId", "ProdutoId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "PontoDeVendaProduto",
                keyColumns: new[] { "PontoDeVendaId", "ProdutoId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "PontosDeVenda",
                keyColumn: "PontoDeVendaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PontosDeVenda",
                keyColumn: "PontoDeVendaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 4);
        }
    }
}
