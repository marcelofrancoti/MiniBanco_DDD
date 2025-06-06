using MediatR;
using  Cliente.Aplication.Empresa.Request;
using  Cliente.Contracts;
using  Cliente.Intrastruture;
using  Cliente.Intrastruture.Services;
using  Cliente.Intrastruture.Services.InsegracaoService;

namespace  Cliente.Aplication
{
    public class InsertEmpresaHandler : IRequestHandler<EmpresaInserirRequest, Response<long>>
    {
        private readonly EmpresaCommandStore _commandStore;
        private readonly KeyCloakService _keyCloackService;
        private readonly TokenKeyCloack _tokenService;

        public InsertEmpresaHandler(
            EmpresaCommandStore commandStore,
            TokenKeyCloack tokenService,
            KeyCloakService keyCloackService)
        {
            _commandStore = commandStore;
            _tokenService = tokenService;
            _keyCloackService = keyCloackService;
        }

        public async Task<Response<long>> Handle(EmpresaInserirRequest request, CancellationToken cancellationToken)
        {
            // Definir a data de inativação se a situação for 0
            var empresa = new Domain.Entities.Empresa
            {
                Nome = request.EmpresaDto.Nome.ToString(),
                Cnpj = request.EmpresaDto.Cnpj.ToString(),
                Tipo = Convert.ToInt32(request.EmpresaDto.Tipo),
                DataInativacao = request.EmpresaDto.Situacao == 0 ? DateTime.Now : (DateTime?)null,
                CodigoKeycloak = string.Empty,
                DataRegistro = DateTime.UtcNow
            };

            // Inserir empresa no banco de dados
            var idEmpresa = await _commandStore.InserirEmpresaAsync(empresa);

            if (idEmpresa <= 0)
            {
                return new Response<long>
                {
                    Data = 0,
                    Success = false,
                    Message = "Falha ao inserir a empresa no banco de dados."
                };
            }

            // Obter o token de autenticação do Keycloak
            var Token = await _tokenService.GetTokenAsync();

            // Cadastrar o grupo no Keycloak usando o nome da empresa
            _keyCloackService.CriarRealmAsync(Token.AccessToken, empresa.Nome);

            // Atualizar o campo cdkeycloak no banco de dados com o ID retor nado pelo Keycloak

            var rowsAffected = await _commandStore.AlterarEmpresaAsync(empresa);

            if (rowsAffected > 0)
            {
                return new Response<long>
                {
                    Data = idEmpresa,
                    Success = true,
                    Message = "Empresa inserida e integrada com sucesso no Keycloak."
                };
            }
            else
            {
                return new Response<long>
                {
                    Data = idEmpresa,
                    Success = false,
                    Message = "Falha ao atualizar o campo cdkeycloak no banco de dados."
                };
            }
        }
    }
}
