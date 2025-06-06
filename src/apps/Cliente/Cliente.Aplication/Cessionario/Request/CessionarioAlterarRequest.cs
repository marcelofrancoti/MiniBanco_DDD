using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.Cessionario.Request
{
    public class CessionarioAlterarRequest : IRequest<Response<long>>
    {
        public AlterarCessionarioDto CessionarioDto { get; set; }
    }
}
