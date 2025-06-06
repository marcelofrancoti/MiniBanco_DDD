using MediatR;
using  Cliente.Aplication.ContaCorrente.Request;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;
using  Cliente.Intrastruture.Services;

namespace  Cliente.Aplication.ContaCorrente
{
    public class GetIdContaCorrentesHandler : IRequestHandler<ContaCorrenteGetIdRequest, Response<List<ContaCorrenteDto>>>
    {
        private readonly ContaCorrenteQueryStore _queryStore;

        public GetIdContaCorrentesHandler(ContaCorrenteQueryStore queryStore)
        {
            _queryStore = queryStore;
        }

        public async Task<Response<List<ContaCorrenteDto>>> Handle(ContaCorrenteGetIdRequest request, CancellationToken cancellationToken)
        {
            // Obter dados filtrados
            var contaCorrente = await _queryStore.GetIdContaCorrentesAsync(request.Id);

            if (contaCorrente != null && !contaCorrente.Any())
            {
                return new Response<List<ContaCorrenteDto>>
                {
                    Data = contaCorrente,
                    Success = false,
                    Message = "Nenhuma Conta Correntes encontrada.",
                };
            }
            // Retornar resposta com a lista paginada
            return new Response<List<ContaCorrenteDto>>
            {
                Data = contaCorrente,
                Success = true,
                Message = "ContaCorrentes listadas com sucesso",
            };
        }
    }
}
