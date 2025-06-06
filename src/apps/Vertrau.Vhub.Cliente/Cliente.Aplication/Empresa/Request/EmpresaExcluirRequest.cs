using MediatR;
using  Cliente.Contracts;

namespace  Cliente.Aplication.Empresa.Request
{
    public class EmpresaExcluirRequest : IRequest<Response<long>>
    {
        public int IdEmpresa { get; set; }
    }
}
