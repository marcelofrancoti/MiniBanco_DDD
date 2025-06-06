using MediatR;
using  Cliente.Aplication.ContaCorrente.Request;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;
using  Cliente.Intrastruture.Services;

namespace  Cliente.Aplication.ContaCorrente
{
    public class ListContaCorrentesHandler : IRequestHandler<ContaCorrenteListarRequest, Response<Paginacao<List<ListarContaCorrenteDto>>>>
    {
        private readonly ContaCorrenteQueryStore _queryStore;

        public ListContaCorrentesHandler(ContaCorrenteQueryStore queryStore)
        {
            _queryStore = queryStore;
        }

        public async Task<Response<Paginacao<List<ListarContaCorrenteDto>>>> Handle(ContaCorrenteListarRequest request, CancellationToken cancellationToken)
        {
            int pagina = request.Pagina.HasValue ? request.Pagina.Value : 1;
            int paginaQuantidadeRegistro = request.PaginaQuantidadeRegistro.HasValue ? request.PaginaQuantidadeRegistro.Value : 50;
            int skip = (pagina - 1) * paginaQuantidadeRegistro;

            if (request.Conta > 0 && request.Agencia > 0)
            {
                var listarContaCorrenteDto = new ListarContaCorrenteDto
                {
                    Id = request.IdBanco ?? 0, // Mapeia `IdBanco` para `Id`
                    Conta = request.Conta.Value,
                    Agencia = request.Agencia.Value,
                    Situacao = request.Situacao.HasValue ? (request.Situacao == 1 ? "Inativo" : "Ativo") : null
                };

                // Obter dados filtrados
                var contaCorrentesFiltradas = await _queryStore.ListarContaCorrentesAsync(listarContaCorrenteDto);

                // Aplicar paginação na lista filtrada
                var paginatedResult = contaCorrentesFiltradas.Skip(skip).Take(paginaQuantidadeRegistro).ToList();

                if (paginatedResult != null && !paginatedResult.Any())
                {
                    return new Response<Paginacao<List<ListarContaCorrenteDto>>>
                    {
                        Success = false,
                        Message = "ContaCorrentes nenhuma conta conrrente encontrada",
                    };
                }

                // Retornar resposta com a lista paginada
                return new Response<Paginacao<List<ListarContaCorrenteDto>>>
                {
                    Data = new Paginacao<List<ListarContaCorrenteDto>>(pagina, paginaQuantidadeRegistro, paginatedResult.Count(), paginatedResult),
                    Success = true,
                    Message = "ContaCorrentes listadas com sucesso",
                };
            }
            else
            {
                // Obter dados filtrados
                var contaCorrentesFiltradas = await _queryStore.ListarContaCorrentesAsync(new ListarContaCorrenteDto());

                // Aplicar paginação na lista filtrada
                var paginatedResult = contaCorrentesFiltradas.Skip(skip).Take(paginaQuantidadeRegistro).ToList();

                // Retornar resposta com a lista paginada
                return new Response<Paginacao<List<ListarContaCorrenteDto>>>
                {
                    Data = new Paginacao<List<ListarContaCorrenteDto>>(pagina, paginaQuantidadeRegistro, paginatedResult.Count(), paginatedResult),
                    Success = true,
                    Message = "ContaCorrentes listadas com sucesso",
                };
            }

        }
    }
}
