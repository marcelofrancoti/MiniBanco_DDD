using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.ContaCorrente.Request
{
    public class ContaCorrenteAlterarRequest : IRequest<Response<long>>
    {
        public ContaCorrenteDto contaCorrente { get; set; }
    }
}
