using MediatR;
using  Cliente.Contracts;

namespace  Cliente.Aplication.ContaCorrente.Request
{
    public class ContaCorrenteExcluirRequest : IRequest<Response<long>>
    {
        public long IdContaCorrente { get; set; }
    }
}
