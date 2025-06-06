using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.TipoUsuario
{
    public class ListTiposUsuarioHandler : IRequestHandler<ListTiposUsuarioRequest, Response<List<TipoUsuarioDto>>>
    {
        public async Task<Response<List<TipoUsuarioDto>>> Handle(ListTiposUsuarioRequest request, CancellationToken cancellationToken)
        {
            var tiposUsuario = new List<TipoUsuarioDto>
            {
                new TipoUsuarioDto { Value = "1", Label = "FIDD" }
            };

            return new Response<List<TipoUsuarioDto>>
            {
                Data = tiposUsuario,
                Success = true,
                Message = "Tipos de usuário obtidos com sucesso."
            };
        }
    }
}
