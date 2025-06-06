using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.Cessionario.Request
{
    public class CessionarioListarPorIdRequest : IRequest<Response<Paginacao<List<ListarCessionarioDto>>>>
    {
        public long Id { get; set; }
        public CessionarioListarPorIdRequest(long id)
        {
            Id = id;
        }
    }
}
