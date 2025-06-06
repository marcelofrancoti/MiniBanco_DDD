using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace  Cliente.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddTabelas__03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_usuario",
                table: "usuario");

            migrationBuilder.DropPrimaryKey(
                name: "pk_empresa",
                table: "empresa");

            migrationBuilder.DropPrimaryKey(
                name: "pk_cessionario",
                table: "cessionario");

            migrationBuilder.DropPrimaryKey(
                name: "pk_banco",
                table: "banco");

            migrationBuilder.DropPrimaryKey(
                name: "pk_usuario_empresa",
                table: "usuario_empresa");

            migrationBuilder.DropPrimaryKey(
                name: "pk_operacoe",
                table: "operacoe");

            migrationBuilder.DropPrimaryKey(
                name: "pk_operacao_cedente",
                table: "operacao_cedente");

            migrationBuilder.DropPrimaryKey(
                name: "pk_conta_corrente",
                table: "conta_corrente");

            migrationBuilder.RenameTable(
                name: "usuario",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "empresa",
                newName: "Empresa");

            migrationBuilder.RenameTable(
                name: "cessionario",
                newName: "Cessionario");

            migrationBuilder.RenameTable(
                name: "banco",
                newName: "Banco");

            migrationBuilder.RenameTable(
                name: "usuario_empresa",
                newName: "UsuarioEmpresa");

            migrationBuilder.RenameTable(
                name: "operacoe",
                newName: "Operacao");

            migrationBuilder.RenameTable(
                name: "operacao_cedente",
                newName: "OperacaoCedente");

            migrationBuilder.RenameTable(
                name: "conta_corrente",
                newName: "ContaCorrente");

            migrationBuilder.RenameColumn(
                name: "situacao",
                table: "Usuario",
                newName: "Situacao");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Usuario",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Usuario",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Usuario",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id_tipo_usuario",
                table: "Usuario",
                newName: "IdTipoUsuario");

            migrationBuilder.RenameColumn(
                name: "id_configuracao_perfil",
                table: "Usuario",
                newName: "IdConfiguracaoPerfil");

            migrationBuilder.RenameColumn(
                name: "data_inativacao",
                table: "Usuario",
                newName: "DataInativacao");

            migrationBuilder.RenameColumn(
                name: "data_exclusao",
                table: "Usuario",
                newName: "DataExclusao");

            migrationBuilder.RenameColumn(
                name: "codigo_keycloak",
                table: "Usuario",
                newName: "CodigoKeycloak");

            migrationBuilder.RenameColumn(
                name: "tipo",
                table: "Empresa",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Empresa",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "cnpj",
                table: "Empresa",
                newName: "Cnpj");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Empresa",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "data_inativacao",
                table: "Empresa",
                newName: "DataInativacao");

            migrationBuilder.RenameColumn(
                name: "codigo_keycloak",
                table: "Empresa",
                newName: "CodigoKeycloak");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Cessionario",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "cnpj",
                table: "Cessionario",
                newName: "Cnpj");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Cessionario",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id_banco_custodiante",
                table: "Cessionario",
                newName: "IdBancoCustodiante");

            migrationBuilder.RenameColumn(
                name: "id_administrador",
                table: "Cessionario",
                newName: "IdAdministrador");

            migrationBuilder.RenameColumn(
                name: "data_inativacao",
                table: "Cessionario",
                newName: "DataInativacao");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Banco",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Banco",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "codigo_banco",
                table: "Banco",
                newName: "CodigoBanco");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UsuarioEmpresa",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id_usuario",
                table: "UsuarioEmpresa",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "id_empresa",
                table: "UsuarioEmpresa",
                newName: "IdEmpresa");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Operacao",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "detalhe",
                table: "Operacao",
                newName: "Detalhe");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Operacao",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id_modalidade_operacao",
                table: "Operacao",
                newName: "IdModalidadeOperacao");

            migrationBuilder.RenameColumn(
                name: "id_cessionario",
                table: "Operacao",
                newName: "IdCessionario");

            migrationBuilder.RenameColumn(
                name: "data_inativacao",
                table: "Operacao",
                newName: "DataInativacao");

            migrationBuilder.RenameColumn(
                name: "conta_cobranca",
                table: "Operacao",
                newName: "ContaCobranca");

            migrationBuilder.RenameColumn(
                name: "coobrigacao",
                table: "OperacaoCedente",
                newName: "Coobrigacao");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "OperacaoCedente",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id_operacao",
                table: "OperacaoCedente",
                newName: "IdOperacao");

            migrationBuilder.RenameColumn(
                name: "id_empresa",
                table: "OperacaoCedente",
                newName: "IdEmpresa");

            migrationBuilder.RenameColumn(
                name: "conta",
                table: "ContaCorrente",
                newName: "Conta");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ContaCorrente",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empresa",
                table: "Empresa",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cessionario",
                table: "Cessionario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Banco",
                table: "Banco",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioEmpresa",
                table: "UsuarioEmpresa",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operacao",
                table: "Operacao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperacaoCedente",
                table: "OperacaoCedente",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContaCorrente",
                table: "ContaCorrente",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empresa",
                table: "Empresa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cessionario",
                table: "Cessionario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Banco",
                table: "Banco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioEmpresa",
                table: "UsuarioEmpresa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperacaoCedente",
                table: "OperacaoCedente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operacao",
                table: "Operacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContaCorrente",
                table: "ContaCorrente");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "usuario");

            migrationBuilder.RenameTable(
                name: "Empresa",
                newName: "empresa");

            migrationBuilder.RenameTable(
                name: "Cessionario",
                newName: "cessionario");

            migrationBuilder.RenameTable(
                name: "Banco",
                newName: "banco");

            migrationBuilder.RenameTable(
                name: "UsuarioEmpresa",
                newName: "usuario_empresa");

            migrationBuilder.RenameTable(
                name: "OperacaoCedente",
                newName: "operacao_cedente");

            migrationBuilder.RenameTable(
                name: "Operacao",
                newName: "operacoe");

            migrationBuilder.RenameTable(
                name: "ContaCorrente",
                newName: "conta_corrente");

            migrationBuilder.RenameColumn(
                name: "Situacao",
                table: "usuario",
                newName: "situacao");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "usuario",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "usuario",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "usuario",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IdTipoUsuario",
                table: "usuario",
                newName: "id_tipo_usuario");

            migrationBuilder.RenameColumn(
                name: "IdConfiguracaoPerfil",
                table: "usuario",
                newName: "id_configuracao_perfil");

            migrationBuilder.RenameColumn(
                name: "DataInativacao",
                table: "usuario",
                newName: "data_inativacao");

            migrationBuilder.RenameColumn(
                name: "DataExclusao",
                table: "usuario",
                newName: "data_exclusao");

            migrationBuilder.RenameColumn(
                name: "CodigoKeycloak",
                table: "usuario",
                newName: "codigo_keycloak");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "empresa",
                newName: "tipo");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "empresa",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Cnpj",
                table: "empresa",
                newName: "cnpj");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "empresa",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DataInativacao",
                table: "empresa",
                newName: "data_inativacao");

            migrationBuilder.RenameColumn(
                name: "CodigoKeycloak",
                table: "empresa",
                newName: "codigo_keycloak");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "cessionario",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Cnpj",
                table: "cessionario",
                newName: "cnpj");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cessionario",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IdBancoCustodiante",
                table: "cessionario",
                newName: "id_banco_custodiante");

            migrationBuilder.RenameColumn(
                name: "IdAdministrador",
                table: "cessionario",
                newName: "id_administrador");

            migrationBuilder.RenameColumn(
                name: "DataInativacao",
                table: "cessionario",
                newName: "data_inativacao");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "banco",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "banco",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CodigoBanco",
                table: "banco",
                newName: "codigo_banco");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "usuario_empresa",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "usuario_empresa",
                newName: "id_usuario");

            migrationBuilder.RenameColumn(
                name: "IdEmpresa",
                table: "usuario_empresa",
                newName: "id_empresa");

            migrationBuilder.RenameColumn(
                name: "Coobrigacao",
                table: "operacao_cedente",
                newName: "coobrigacao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "operacao_cedente",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IdOperacao",
                table: "operacao_cedente",
                newName: "id_operacao");

            migrationBuilder.RenameColumn(
                name: "IdEmpresa",
                table: "operacao_cedente",
                newName: "id_empresa");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "operacoe",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Detalhe",
                table: "operacoe",
                newName: "detalhe");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "operacoe",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IdModalidadeOperacao",
                table: "operacoe",
                newName: "id_modalidade_operacao");

            migrationBuilder.RenameColumn(
                name: "IdCessionario",
                table: "operacoe",
                newName: "id_cessionario");

            migrationBuilder.RenameColumn(
                name: "DataInativacao",
                table: "operacoe",
                newName: "data_inativacao");

            migrationBuilder.RenameColumn(
                name: "ContaCobranca",
                table: "operacoe",
                newName: "conta_cobranca");

            migrationBuilder.RenameColumn(
                name: "Conta",
                table: "conta_corrente",
                newName: "conta");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "conta_corrente",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_usuario",
                table: "usuario",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_empresa",
                table: "empresa",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_cessionario",
                table: "cessionario",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_banco",
                table: "banco",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_usuario_empresa",
                table: "usuario_empresa",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_operacao_cedente",
                table: "operacao_cedente",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_operacoe",
                table: "operacoe",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_conta_corrente",
                table: "conta_corrente",
                column: "id");
        }
    }
}
