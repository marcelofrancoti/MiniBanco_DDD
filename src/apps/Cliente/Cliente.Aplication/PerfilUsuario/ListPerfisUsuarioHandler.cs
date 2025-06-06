using MediatR;
using  Cliente.Aplication.PerfilUsuario.Request;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.PerfilUsuario
{
    public class ListPerfisUsuarioHandler : IRequestHandler<ListPerfisUsuarioRequest, Response<List<PerfilUsuarioDto>>>
    {
        public async Task<Response<List<PerfilUsuarioDto>>> Handle(ListPerfisUsuarioRequest request, CancellationToken cancellationToken)
        {
            var perfisUsuario = new List<PerfilUsuarioDto>
            {
                new PerfilUsuarioDto { Value = "1", Label = "Leitura" },
                new PerfilUsuarioDto { Value = "2", Label = "Gerenciamento" }
            };

            return new Response<List<PerfilUsuarioDto>>
            {
                Data = perfisUsuario,
                Success = true,
                Message = "Perfis de usuário obtidos com sucesso."
            };
        }
    }
}
