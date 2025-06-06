using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.PerfilUsuario.Request
{
    public class ListPerfisUsuarioRequest : IRequest<Response<List<PerfilUsuarioDto>>>
    {
    }
}
