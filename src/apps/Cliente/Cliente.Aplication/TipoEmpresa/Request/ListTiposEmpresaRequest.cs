using MediatR;
using  Cliente.Contracts.Dto;
using  Cliente.Contracts;

namespace  Cliente.Aplication.TipoEmpresa.Request
{
    public class ListTiposEmpresaRequest : IRequest<Response<List<TipoEmpresaDto>>>
    {
        public ListTiposEmpresaRequest()
        {
        }
    }
}
