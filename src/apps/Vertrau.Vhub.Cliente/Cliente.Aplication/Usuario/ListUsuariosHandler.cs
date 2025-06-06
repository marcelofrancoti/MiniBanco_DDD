using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;
using  Cliente.Intrastruture;
using  Cliente.Intrastruture.Services;

namespace  Cliente.Aplication.Usuario
{
    public class ListUsuariosHandler : IRequestHandler<ListUsuariosRequest, Response<List<UsuarioDto>>>
    {
        private readonly UsuarioQueryStore _queryStore;


        public ListUsuariosHandler(UsuarioQueryStore queryStore)
        {
            _queryStore = queryStore;
        }

        public async Task<Response<List<UsuarioDto>>> Handle(ListUsuariosRequest request, CancellationToken cancellationToken)
        {
            var pagina = request.Pagina > 0 ? request.Pagina : 1;
            var paginaQuantidadeRegistro = request.PaginaQuantidadeRegistro > 0 ? request.PaginaQuantidadeRegistro : 30;

            var usuarios = await _queryStore.ListarUsuariosAsync(request, pagina, paginaQuantidadeRegistro);

            var quantidadeRegistros = await _queryStore.ContarUsuariosAsync(request);

            if (!usuarios.Any())
            {
                return new Response<List<UsuarioDto>>
                {
                    Success = false,
                    Message = "Nenhum usuário encontrado"
                };
            }

            var usuarioLogado = "_currentUserService.GetCodigoKeycloak()";
            var usuariosDto = usuarios.Select(usuario => new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                TipoUsuario = usuario.IdTipoUsuario == 1 ? "Vertrau" : "Cliente",
                Perfil = usuario.IdConfiguracaoPerfil == 1 ? "Leitura" : "Gerenciamento",
                Situacao = usuario.DataInativacao.HasValue ? "Inativo" : "Ativo",
                Acoes = new AcoesDto
                {
                    Editar = usuario.CodigoKeycloak != usuarioLogado,
                    Excluir = usuario.CodigoKeycloak != usuarioLogado
                }
            }).ToList();

            return new Response<List<UsuarioDto>>
            {
                Success = true,
                Data = usuariosDto
            };
        }
    }
}
