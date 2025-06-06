using MediatR;
using  Cliente.Contracts.Dto;
using  Cliente.Contracts;

namespace  Cliente.Aplication.ContaCorrente.Request
{
    public class ListContasCorrentesRequest : IRequest<Response<List<ContaCorrenteEnumDto>>>
    {
    }
}
