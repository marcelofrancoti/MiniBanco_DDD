using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.Usuario.Request
{
    public class GetIdUsuarioRequest : IRequest<Response<UsuarioDto>>
    {
        public int IdUsuario { get; set; }
    }
}
