using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.Empresa.Request
{
    public class GetEmpresaByIdRequest : IRequest<Response<EmpresaDto>>
    {
        public int Id { get; set; }

        public GetEmpresaByIdRequest(int id)
        {
            Id = id;
        }
    }
}
