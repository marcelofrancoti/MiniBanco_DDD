using MediatR;
using  Cliente.Aplication.Operacao.Request;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.Operacao
{
    public class ListOperacaoHandler : IRequestHandler<OperacaoListarRequest, Response<Paginacao<List<OperacaoDto>>>>
    {
        private readonly OperacaoQueryStore _operacaoQueryStore;

        public ListOperacaoHandler(OperacaoQueryStore operacaoQueryStore)
        {
            _operacaoQueryStore = operacaoQueryStore;
        }

        public async Task<Response<Paginacao<List<OperacaoDto>>>> Handle(OperacaoListarRequest request, CancellationToken cancellationToken)
        {
            // Define default pagination values
            int pagina =  1;
            int paginaQuantidadeRegistro = 30;

            // Retrieve all operations
            var result = await _operacaoQueryStore.GetOperacoesAsync();

            if (result.Count == 0)
            {
                return new Response<Paginacao<List<OperacaoDto>>>
                {
                    Success = false,
                    Message = "Nenhuma operação encontrada."
                };
            }

            // Apply manual pagination
            var paginatedData = result
                .Skip((pagina - 1) * paginaQuantidadeRegistro)
                .Take(paginaQuantidadeRegistro)
                .ToList();

            // Create paginated response data
            var paginacao = new Paginacao<List<OperacaoDto>>(
                pagina,
                paginaQuantidadeRegistro,
                result.Count,
                paginatedData
            );

            return new Response<Paginacao<List<OperacaoDto>>>
            {
                Success = true,
                Message = "Operações listadas com sucesso.",
                Data = paginacao
            };
        }

    }
}
