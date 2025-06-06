using MediatR;
using  Cliente.Aplication.Usuario.Request;
using  Cliente.Contracts;
using  Cliente.Intrastruture;
using  Cliente.Intrastruture.Services;
using  Cliente.Intrastruture.Services.InsegracaoService;

namespace  Cliente.Aplication.Usuario
{
    public class DeleteUsuarioHandler : IRequestHandler<DeleteUsuarioRequest, Response<long>>
    {
        private readonly UsuarioCommandStore _usuarioCommandStore;
        private readonly KeyCloakService _keycloakService;
        private readonly TokenKeyCloack _tokenKeyCloack;

        public DeleteUsuarioHandler(UsuarioCommandStore usuarioCommandStore, KeyCloakService keycloakService, TokenKeyCloack tokenKeyCloack)
        {
            _usuarioCommandStore = usuarioCommandStore;
            _keycloakService = keycloakService;
            _tokenKeyCloack = tokenKeyCloack;
        }

        public async Task<Response<long>> Handle(DeleteUsuarioRequest request, CancellationToken cancellationToken)
        {
            var accessToken = await _tokenKeyCloack.GetTokenAsync();

            // altera usuario no banco dedados 
            var usuario = await _usuarioCommandStore.ObterUsuarioPorIdAsync(request.IdUsuario);
            if (usuario == null)
            {

                return new Response<long>
                {
                    Success = false,
                    Message = "Usuário não encontrado"
                };

            }

            //deleta o usuario do passando a data de explizão
            usuario.DataExclusao = DateTime.UtcNow;
            await _usuarioCommandStore.AlterarUsuarioAsync(usuario);

            //removendo usuario do keycloack
            var keycloakResult = await _keycloakService.DeleteUserAsync(usuario.CodigoKeycloak, accessToken.AccessToken);
            if (!keycloakResult)
            {
                return new Response<long>
                {
                    Success = false,
                    Message = "Erro ao remover o usuário do Keycloak"
                };
            }

            return new Response<long>
            {
                Success = false,
                Data = usuario.Id, 
                Message = "Usuário excluído com sucesso"
            };

        }
    }
}
