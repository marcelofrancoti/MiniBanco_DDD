using MediatR;
using  Cliente.Aplication.Empresa.Request;
using  Cliente.Contracts;
using  Cliente.Intrastruture;
using  Cliente.Intrastruture.Services;
using  Cliente.Intrastruture.Services.InsegracaoService;



namespace  Cliente.Aplication.Empresa
{
    public class AlterEmpresaHandler : IRequestHandler<EmpresaAlterarRequest, Response<long>>
    {
        private readonly EmpresaCommandStore _commandStore;
        private readonly EmpresaQueryStore _queryStore;
        private readonly KeyCloakService _keyCloackService;
        private readonly TokenKeyCloack _tokenService;

        public AlterEmpresaHandler(
            EmpresaCommandStore commandStore,
            EmpresaQueryStore queryStore,
            KeyCloakService keyCloackService,
            TokenKeyCloack tokenService)
        {
            _commandStore = commandStore;
            _queryStore = queryStore;
            _keyCloackService = keyCloackService;
            _tokenService = tokenService;
        }

        public async Task<Response<long>> Handle(EmpresaAlterarRequest request, CancellationToken cancellationToken)
        {
            // Buscar a empresa no banco de dados
            var empresa = await _queryStore.BuscarEmpresaPorIdAsync(request.EmpresaDto.Id);

            if (empresa == null)
            {
                return new Response<long>
                {
                    Success = false,
                    Message = "Empresa não encontrada"
                };
            }

            // Verificar se o nome foi alterado
            bool nomeAlterado = empresa.Nome != request.EmpresaDto.Nome;

            // Atualizar os dados da empresa
            empresa.Nome = request.EmpresaDto.Nome;
            empresa.Cnpj = request.EmpresaDto.Cnpj;
            empresa.Tipo = request.EmpresaDto.Tipo;

            // Lógica da situação e data de inativação
            if (request.EmpresaDto.Situacao == 0 && !empresa.DataInativacao.HasValue)
            {
                empresa.DataInativacao = DateTime.Now;
            }
            else if (request.EmpresaDto.Situacao == 1 && empresa.DataInativacao.HasValue)
            {
                empresa.DataInativacao = null;
            }

            // Se o nome foi alterado, integrar com o Keycloak
            if (nomeAlterado)
            {
                var accessToken = await _tokenService.GetTokenAsync();
                var keycloakResponse = await _keyCloackService.AtualizarNomeGrupoNoKeycloak(accessToken.AccessToken, empresa.Id.ToString(), empresa.Nome);

                if (!keycloakResponse.Success)
                {
                    return new Response<long>
                    {
                        Success = false,
                        Message = "Falha ao atualizar o nome no Keycloak"
                    };
                }
            }

            // Atualizar empresa no banco de dados
            var rowsAffected = await _commandStore.AlterarEmpresaAsync(empresa);

            if (rowsAffected > 0)
            {
                return new Response<long>
                {
                    Success = true,
                    Data = empresa.Id,
                    Message = "Empresa atualizada com sucesso"
                };
            }
            else
            {
                return new Response<long>
                {
                    Success = false,
                    Message = "Falha ao atualizar a empresa"
                };
            }
        }
    }
}
