using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.Operacao.Request
{
    public class OperacaoListarRequest : IRequest<Response<Paginacao<List<OperacaoDto>>>>
    {
    }
}
