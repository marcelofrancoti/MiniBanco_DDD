using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.Usuario.Request
{
    public class AlterUsuarioRequest : IRequest<Response<long>>
    {
        public UsuarioAlterDto usuarioDto { get; set; }

        public AlterUsuarioRequest(UsuarioAlterDto usuarioDto)
        {
            this.usuarioDto = usuarioDto;
        }



    }
}
