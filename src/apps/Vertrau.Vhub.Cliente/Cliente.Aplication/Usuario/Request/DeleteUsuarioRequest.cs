using MediatR;
using  Cliente.Contracts;

namespace  Cliente.Aplication.Usuario.Request
{
    public record DeleteUsuarioRequest(int IdUsuario) : IRequest<Response<long>>;
}