using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.Operacao.Request
{
    public class OperacaoAlterarRequest : IRequest<Response<long>>
    {
        public OperacaoDto OperacaoDto { get; set; }
    }
}
