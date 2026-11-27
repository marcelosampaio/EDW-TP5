using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDW_TP5.Migrations
{
    /// <inheritdoc />
    public partial class AddProdutosEPontosDeVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PontosDeVenda",
                columns: table => new
                {
                    PontoDeVendaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    EventoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosDeVenda", x => x.PontoDeVendaId);
                    table.ForeignKey(
                        name: "FK_PontosDeVenda_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Preco = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "PontoDeVendaProduto",
                columns: table => new
                {
                    PontoDeVendaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontoDeVendaProduto", x => new { x.PontoDeVendaId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_PontoDeVendaProduto_PontosDeVenda_PontoDeVendaId",
                        column: x => x.PontoDeVendaId,
                        principalTable: "PontosDeVenda",
                        principalColumn: "PontoDeVendaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PontoDeVendaProduto_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PontoDeVendaProduto_ProdutoId",
                table: "PontoDeVendaProduto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosDeVenda_EventoId",
                table: "PontosDeVenda",
                column: "EventoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PontoDeVendaProduto");

            migrationBuilder.DropTable(
                name: "PontosDeVenda");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
