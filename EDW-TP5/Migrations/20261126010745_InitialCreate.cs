using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDW_TP5.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    DataHoraInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataHoraFim = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoId);
                });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "EventoId", "DataHoraFim", "DataHoraInicio", "Nome" },
                values: new object[] { 1, new DateTime(2026, 12, 20, 23, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 12, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), "Dezembro Junino" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
