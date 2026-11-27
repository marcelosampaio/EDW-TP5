using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EDW_TP5.Migrations
{
    /// <inheritdoc />
    public partial class AddCarteirasEFuncionarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarteirasDigitais",
                columns: table => new
                {
                    CarteiraDigitalId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QrCode = table.Column<string>(type: "TEXT", nullable: false),
                    Saldo = table.Column<decimal>(type: "TEXT", nullable: false),
                    EventoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarteirasDigitais", x => x.CarteiraDigitalId);
                    table.ForeignKey(
                        name: "FK_CarteirasDigitais_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    TipoFuncionario = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    PontoDeVendaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionarios_PontosDeVenda_PontoDeVendaId",
                        column: x => x.PontoDeVendaId,
                        principalTable: "PontosDeVenda",
                        principalColumn: "PontoDeVendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "FuncionarioId", "Nome", "TipoFuncionario" },
                values: new object[,]
                {
                    { 1, "Carlos Mendes", "Organizador" },
                    { 2, "Ana Souza", "OperadorCaixa" }
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "FuncionarioId", "Nome", "PontoDeVendaId", "TipoFuncionario" },
                values: new object[,]
                {
                    { 3, "João Silva", 1, "Vendedor" },
                    { 4, "Pedro Santos", 2, "Vendedor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarteirasDigitais_EventoId",
                table: "CarteirasDigitais",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_PontoDeVendaId",
                table: "Funcionarios",
                column: "PontoDeVendaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarteirasDigitais");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
