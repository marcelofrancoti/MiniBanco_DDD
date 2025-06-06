using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.ModalidadeOperacao
{
    public class ListModalidadesOperacaoRequest : IRequest<Response<List<ModalidadeOperacaoDto>>>
    {
    }
}
