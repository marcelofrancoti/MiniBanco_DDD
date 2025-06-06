using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.Operacao.Request
{
    public class OperacaoInserirRequest : IRequest<Response<long>>
    {
        public InserirOperacaoDto InserirOperacaoDto { get; set; }
    }
}
