using MediatR;
using  Cliente.Aplication.Requisicoes;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;
using  Cliente.Intrastruture.Services;

namespace  Cliente.Aplication.Empresa
{
    public class ListEmpresaHandler : IRequestHandler<EmpresaListarRequest, Response<List<EmpresaDto>>>
    {
        private readonly EmpresaQueryStore _queryStore;

        public ListEmpresaHandler(EmpresaQueryStore queryStore)
        {
            _queryStore = queryStore;
        }

        public async Task<Response<List<EmpresaDto>>> Handle(EmpresaListarRequest request, CancellationToken cancellationToken)
        {
            var empresas = await _queryStore.ListarEmpresasFiltradasAsync(request);

            if (empresas != null && empresas.Any())
            {
                var empresasDto = empresas.Select(e => new EmpresaDto
                {
                    Id = e.Id,
                    Nome = e.Nome,
                    Cnpj = e.Cnpj,
                    Tipo = e.Tipo,
                    Situacao = e.DataInativacao.HasValue ? 0 : 1
                }).ToList();

                return new Response<List<EmpresaDto>>
                {
                    Success = true,
                    Data = empresasDto,
                    Message = "Empresas listadas com sucesso"
                };
            }
            else
            {
                return new Response<List<EmpresaDto>>
                {
                    Success = false,
                    Data = null,
                    Message = "Nenhuma empresa encontrada"
                };
            }
        }

    }
}
