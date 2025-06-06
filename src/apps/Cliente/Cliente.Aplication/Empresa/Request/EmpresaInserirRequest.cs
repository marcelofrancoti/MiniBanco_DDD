using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.Empresa.Request
{
    public class EmpresaInserirRequest : IRequest<Response<long>>
    {
        public InserirEmpresaDto EmpresaDto { get; set; }
    }
}
