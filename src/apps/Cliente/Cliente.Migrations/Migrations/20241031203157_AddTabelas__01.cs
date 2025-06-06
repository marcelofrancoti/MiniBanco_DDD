using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace  Cliente.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddTabelas__01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "banco",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    codigo_banco = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    data_registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_banco", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cessionario",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_administrador = table.Column<int>(type: "integer", nullable: false),
                    id_banco_custodiante = table.Column<int>(type: "integer", nullable: true),
                    nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    cnpj = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    data_inativacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    data_registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cessionario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "conta_corrente",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_banco = table.Column<int>(type: "integer", nullable: false),
                    conta = table.Column<int>(type: "integer", nullable: false),
                    agencia = table.Column<int>(type: "integer", nullable: false),
                    agencia_digito = table.Column<int>(type: "integer", nullable: false),
                    data_inativacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    data_registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_conta_corrente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "empresa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    cnpj = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    tipo = table.Column<int>(type: "integer", nullable: false),
                    codigo_keycloak = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    data_inativacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    data_registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_empresa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "operacao_cedente",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_operacao = table.Column<int>(type: "integer", nullable: false),
                    id_empresa = table.Column<int>(type: "integer", nullable: false),
                    coobrigacao = table.Column<bool>(type: "boolean", nullable: false),
                    data_registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_operacao_cedente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "operacoe",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_cessionario = table.Column<int>(type: "integer", nullable: false),
                    id_modalidade_operacao = table.Column<int>(type: "integer", nullable: false),
                    nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    detalhe = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    conta_cobranca = table.Column<int>(type: "integer", nullable: false),
                    data_inativacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    data_registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_operacoe", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_configuracao_perfil = table.Column<int>(type: "integer", nullable: false),
                    id_tipo_usuario = table.Column<int>(type: "integer", nullable: false),
                    nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    codigo_keycloak = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false),
                    data_inativacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    data_exclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    data_registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario_empresa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_usuario = table.Column<int>(type: "integer", nullable: false),
                    id_empresa = table.Column<int>(type: "integer", nullable: false),
                    data_registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuario_empresa", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "banco");

            migrationBuilder.DropTable(
                name: "cessionario");

            migrationBuilder.DropTable(
                name: "conta_corrente");

            migrationBuilder.DropTable(
                name: "empresa");

            migrationBuilder.DropTable(
                name: "operacao_cedente");

            migrationBuilder.DropTable(
                name: "operacoe");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "usuario_empresa");
        }
    }
}
