using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace  Cliente.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddTabelas__04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OperacaoId",
                table: "OperacaoCedente",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OperacaoHorarioExecucao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdOperacao = table.Column<int>(type: "integer", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "interval", nullable: false),
                    OperacaoId = table.Column<long>(type: "bigint", nullable: true),
                    DataRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacaoHorarioExecucao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperacaoHorarioExecucao_Operacao_OperacaoId",
                        column: x => x.OperacaoId,
                        principalTable: "Operacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OperacaoParametro",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdOperacao = table.Column<int>(type: "integer", nullable: false),
                    IdAdministradorParametro = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<string>(type: "character varying(600)", maxLength: 600, nullable: false),
                    OperacaoId = table.Column<long>(type: "bigint", nullable: true),
                    DataRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacaoParametro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperacaoParametro_Operacao_OperacaoId",
                        column: x => x.OperacaoId,
                        principalTable: "Operacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperacaoCedente_OperacaoId",
                table: "OperacaoCedente",
                column: "OperacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_OperacaoHorarioExecucao_OperacaoId",
                table: "OperacaoHorarioExecucao",
                column: "OperacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_OperacaoParametro_OperacaoId",
                table: "OperacaoParametro",
                column: "OperacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_OperacaoCedente_Operacao_OperacaoId",
                table: "OperacaoCedente",
                column: "OperacaoId",
                principalTable: "Operacao",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperacaoCedente_Operacao_OperacaoId",
                table: "OperacaoCedente");

            migrationBuilder.DropTable(
                name: "OperacaoHorarioExecucao");

            migrationBuilder.DropTable(
                name: "OperacaoParametro");

            migrationBuilder.DropIndex(
                name: "IX_OperacaoCedente_OperacaoId",
                table: "OperacaoCedente");

            migrationBuilder.DropColumn(
                name: "OperacaoId",
                table: "OperacaoCedente");
        }
    }
}
