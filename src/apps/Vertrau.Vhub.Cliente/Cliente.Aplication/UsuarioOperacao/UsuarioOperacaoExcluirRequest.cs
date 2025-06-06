using MediatR;
using  Cliente.Contracts;

namespace  Cliente.Aplication.UsuarioOperacao
{
    public class UsuarioOperacaoExcluirRequest : IRequest<Response<int>>
    {
        public int IdUsuarioOperacao { get; set; }
    }
}
