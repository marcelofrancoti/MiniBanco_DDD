using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.ContaCorrente.Request
{
    public class ContaCorrenteGetIdRequest : IRequest<Response<List<ContaCorrenteDto>>>
    {
        public long Id { get; set; }

        public ContaCorrenteGetIdRequest(long id)
        {
            Id = id;
        }
    }
}
