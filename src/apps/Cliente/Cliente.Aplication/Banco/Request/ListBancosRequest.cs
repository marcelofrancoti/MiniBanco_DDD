using MediatR;
using  Cliente.Contracts.Dto;
using  Cliente.Contracts;

namespace  Cliente.Aplication.Banco.Request
{
    public class ListBancosRequest : IRequest<Response<List<BancoDto>>>
    {
    }
}
