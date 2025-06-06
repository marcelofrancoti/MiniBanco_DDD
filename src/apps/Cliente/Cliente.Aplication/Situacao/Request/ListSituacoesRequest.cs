using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.Situacao.Request
{
    public class ListSituacoesRequest : IRequest<Response<List<SituacaoDto>>>
    {
    }
}
