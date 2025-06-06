using MediatR;
using  Cliente.Aplication.Cessionario.Request;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;
using  Cliente.Intrastruture.Services;

namespace  Cliente.Aplication.Cessionario.Handlers
{
    public class GetCessionariosHandler : IRequestHandler<CessionarioListarRequest, Response<Paginacao<List<ListCessionarioDto>>>>
    {
        private readonly CessionarioQueryStore _cessionarioQueryStore;

        public GetCessionariosHandler(CessionarioQueryStore cessionarioQueryStore)
        {
            _cessionarioQueryStore = cessionarioQueryStore;
        }

        public async Task<Response<Paginacao<List<ListCessionarioDto>>>> Handle(CessionarioListarRequest request, CancellationToken cancellationToken)
        {
            if (request.Pagina <= 0) request.Pagina = 1;
            if (request.PaginaQuantidadeRegistro <= 0) request.PaginaQuantidadeRegistro = 30;

            var offset = (request.Pagina - 1) * request.PaginaQuantidadeRegistro;

            var result = await _cessionarioQueryStore.GetCessionariosAsync(
                request.Nome,
                request.Cnpj,
                request.Situacao,
                request.Ordenacao,
                request.OrdenacaoColuna,
                offset,
                request.PaginaQuantidadeRegistro
            );

            if (result.Count == 0)
            {
                return new Response<Paginacao<List<ListCessionarioDto>>>
                {
                    Success = false,
                    Message = "Erro: nenhum cessionario encontrado"
                };
            }

            return new Response<Paginacao<List<ListCessionarioDto>>>
            {
                Success = true,
                Message = "Inserido com sucesso",
                Data = new Paginacao<List<ListCessionarioDto>>(request.Pagina,request.PaginaQuantidadeRegistro, result.Count(), result)
            };
        }
    }
}
