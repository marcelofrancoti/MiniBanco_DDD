using MediatR;
using  Cliente.Contracts;

namespace  Cliente.Aplication.Operacao.Request
{
    public class OperacaoExcluirRequest : IRequest<Response<int>>
    {
        public int IdOperacao { get; set; }
    }
}
