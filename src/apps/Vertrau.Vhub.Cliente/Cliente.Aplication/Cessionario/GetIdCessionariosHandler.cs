using MediatR;
using  Cliente.Aplication.Cessionario.Request;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;
using  Cliente.Intrastruture.Services;

namespace  Cliente.Aplication.Cessionario.Handlers
{
    public class GetIdCessionariosHandler : IRequestHandler<CessionarioListarPorIdRequest, Response<Paginacao<List<ListarCessionarioDto>>>>
    {
        private readonly CessionarioQueryStore _cessionarioQueryStore;

        public GetIdCessionariosHandler(CessionarioQueryStore cessionarioQueryStore)
        {
            _cessionarioQueryStore = cessionarioQueryStore;
        }

        public async Task<Response<Paginacao<List<ListarCessionarioDto>>>> Handle(CessionarioListarPorIdRequest request, CancellationToken cancellationToken)
        {
            // Definir valores padrão de paginação
            int pagina = 1; // valor padrão
            int paginaQuantidadeRegistro = 100; // valor padrão

            // Recuperar todos os cessionários pelo ID
            var result = await _cessionarioQueryStore.GetIdCessionariosAsync(request.Id);

            if (result.Count == 0)
            {
                return new Response<Paginacao<List<ListarCessionarioDto>>>
                {
                    Success = false,
                    Message = "Erro: nenhum cessionário encontrado"
                };
            }

            // Aplicar paginação manualmente
            var paginatedData = result
                .Skip((pagina - 1) * paginaQuantidadeRegistro)
                .Take(paginaQuantidadeRegistro)
                .ToList();

            // Retornar resposta com paginação
            return new Response<Paginacao<List<ListarCessionarioDto>>>
            {
                Success = true,
                Message = "Cessionário(s) encontrado(s) com sucesso",
                Data = new Paginacao<List<ListarCessionarioDto>>(pagina, paginaQuantidadeRegistro, result.Count, paginatedData)
            };
        }
    }
}
