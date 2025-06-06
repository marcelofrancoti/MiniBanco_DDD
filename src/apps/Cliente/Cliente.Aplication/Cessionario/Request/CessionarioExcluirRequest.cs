using MediatR;
using  Cliente.Contracts;

namespace  Cliente.Aplication.Cessionario.Request
{
    public class CessionarioExcluirRequest : IRequest<Response<long>>
    {
        public long IdCessionario { get; set; }

    }
}
