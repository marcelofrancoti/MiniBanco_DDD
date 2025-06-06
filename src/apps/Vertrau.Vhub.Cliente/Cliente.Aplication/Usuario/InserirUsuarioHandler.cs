using MediatR;
using  Cliente.Aplication.Usuario.Request;
using  Cliente.Contracts;
using  Cliente.Intrastruture;
using  Cliente.Intrastruture.Services;
using  Cliente.Intrastruture.Services.InsegracaoService;
using  Cliente.Intrastruture.Services.InsegracaoService.EntidadesKeyCloack;



namespace  Cliente.Aplication
{
    public class InserirUsuarioHandler : IRequestHandler<InsertUsuarioRequest, Response<long>>
    {
        private readonly UsuarioCommandStore _usuarioCommandStore;
        private readonly KeyCloakService _keycloakService;
        private readonly TokenKeyCloack _tokenKeyCloack;

        public InserirUsuarioHandler(UsuarioCommandStore usuarioCommandStore, KeyCloakService keycloakService, TokenKeyCloack tokenKeyCloack)
        {
            _usuarioCommandStore = usuarioCommandStore;
            _keycloakService = keycloakService;
            _tokenKeyCloack = tokenKeyCloack;
        }

        public async Task<Response<long>> Handle(InsertUsuarioRequest request, CancellationToken cancellationToken)
        {
            // 1. Validações
            if (string.IsNullOrEmpty(request.Request.Nome) || string.IsNullOrEmpty(request.Request.Email) ||
                request.Request.IdConfiguracaoPerfil == 0 || request.Request.TpUsuario == 0 || request.Request.TpSituacao == 0)
            {
                return new Response<long>
                {
                    Success = false,
                    Message = "Campos obrigatórios não foram enviados, tente novamente."
                };
            }

            if (request.Request.TpUsuario == 2 && (request.Request.IdEmpresas == null || !request.Request.IdEmpresas.Any()))
            {
                return new Response<long>
                {
                    Success = false,
                    Message = "Campo 'idEmpresas' é obrigatório para Tipo de Usuário = 2."
                };
            }

            // 2. Verificação de e-mail único
            var emailExistente = await _usuarioCommandStore.GetByEmailAsync(request.Request.Email, 0);
            if (emailExistente != null)
            {
                return new Response<long>
                {
                    Success = false,
                    Message = "O e-mail informado já está em uso."
                };
            }

            // 3. Inserir o usuário na base de dados
            var novoUsuario = new Domain.Entities.Usuario
            {
                Nome = request.Request.Nome,
                Email = request.Request.Email,
                IdConfiguracaoPerfil = request.Request.IdConfiguracaoPerfil,
                IdTipoUsuario = request.Request.TpUsuario,
                Situacao = request.Request.TpSituacao,
                DataRegistro = DateTime.UtcNow,
                CodigoKeycloak = string.Empty
            };

            var usuarioId = await _usuarioCommandStore.InserirUsuarioAsync(novoUsuario);

            // 4. Geração da senha temporária
            var senhaTemporaria = _keycloakService.GerarSenhaTemporaria();

            // 5. Integração com o Keycloak
            var accessToken = await _tokenKeyCloack.GetTokenAsync();
            var keycloakRequest = new KeycloakUserRequest
            {
                firstName = request.Request.Nome,
                email = request.Request.Email,
                username = request.Request.Email,
                Enabled = request.Request.TpSituacao == 1,
                Groups = request.Request.TpUsuario == 2 ? request.Request.IdEmpresas.Select(e => $"empresa-{e}").ToArray() : null,
                Credentials = new[]
                {
                new KeycloakCredential
                {
                    Type = "password",
                    Value = senhaTemporaria,
                    Temporary = true,
                    CreatedDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                }
            }
            };

            var keycloakResponse = await _keycloakService.CreateUserAsync(accessToken.AccessToken, keycloakRequest);
            if (!keycloakResponse.Success)
            {
                return new Response<long>
                {
                    Success = false,
                    Message = "Falha ao criar usuário no Keycloak."
                };
            }

            // 6. Atualizar CdKeycloak no banco de dados
            await _usuarioCommandStore.AtualizarCdKeycloakAsync(usuarioId, keycloakResponse.Data.KeycloakId);

            // 7. Atribuir role ao usuário no Keycloak com base no IdConfiguracaoPerfil
            var role = await _keycloakService.ObterIdRoleAsync(accessToken.AccessToken, request.Request.Nome);
            await _keycloakService.AtribuirRoleAoUsuario(accessToken.AccessToken, usuarioId.ToString(), role.Id);

            // Retorno de sucesso
            return new Response<long>
            {
                Data = usuarioId,
                Success = true,
                Message = "Usuário criado com sucesso."
            };
        }
    }

}
