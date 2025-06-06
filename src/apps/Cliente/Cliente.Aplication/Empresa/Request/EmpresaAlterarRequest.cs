using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.Empresa.Request
{
    public class EmpresaAlterarRequest : IRequest<Response<long>>
    {
        public EmpresaDto EmpresaDto { get; set; }
    }
}
