using MediatR;
using  Cliente.Aplication.Empresa.Request;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;
using  Cliente.Intrastruture.Services;

namespace  Cliente.Aplication.Empresa
{
    public class GetEmpresaByIdHandler : IRequestHandler<GetEmpresaByIdRequest, Response<EmpresaDto>>
    {
        private readonly EmpresaQueryStore _queryStore;

        public GetEmpresaByIdHandler(EmpresaQueryStore queryStore)
        {
            _queryStore = queryStore;
        }

        public async Task<Response<EmpresaDto>> Handle(GetEmpresaByIdRequest request, CancellationToken cancellationToken)
        {
            // Buscar a empresa pelo ID
            var empresa = await _queryStore.BuscarEmpresaPorIdAsync(request.Id);

            if (empresa == null)
            {
                return new Response<EmpresaDto>
                {
                    Success = false,
                    Message = "Empresa não encontrada"
                };
            }

            // Mapear para o DTO
            var empresaDto = new EmpresaDto
            {
                Id = empresa.Id,
                Nome = empresa.Nome,
                Cnpj = empresa.Cnpj,
                Tipo = empresa.Tipo,
                Situacao = empresa.DataInativacao.HasValue ? 0 : 1
            };

            return new Response<EmpresaDto>
            {
                Success = true,
                Data = empresaDto
            };
        }
    }
}
