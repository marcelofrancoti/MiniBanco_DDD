using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.TipoUsuario
{
    public class ListTiposUsuarioRequest : IRequest<Response<List<TipoUsuarioDto>>>
    {
    }
}
