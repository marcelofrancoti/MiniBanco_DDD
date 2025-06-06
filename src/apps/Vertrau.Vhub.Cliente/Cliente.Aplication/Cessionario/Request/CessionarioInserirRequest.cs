using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.Cessionario.Request
{
    public class CessionarioInserirRequest : IRequest<Response<long>>
    {
        public InserirCessionarioDto CessionarioDto { get; set; }
    }
}
