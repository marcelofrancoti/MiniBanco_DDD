using MediatR;
using  Cliente.Aplication.ContaCorrente.Request;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;
using  Cliente.Intrastruture.Services;

namespace  Cliente.Aplication.ContaCorrente
{
    public class ListContasCorrentesHandler : IRequestHandler<ListContasCorrentesRequest, Response<List<ContaCorrenteEnumDto>>>
    {
        private readonly ContaCorrenteQueryStore _queryStore;
        

        public ListContasCorrentesHandler(ContaCorrenteQueryStore queryStore)
        {
            _queryStore = queryStore;
        }

        public async Task<Response<List<ContaCorrenteEnumDto>>> Handle(ListContasCorrentesRequest request, CancellationToken cancellationToken)
        {
            var contasCorrentes = await _queryStore.ListarContasCorrentesAtivasAsync();

            return new Response<List<ContaCorrenteEnumDto>>
            {
                Data = contasCorrentes,
                Success = true,
                Message = "Contas correntes listadas com sucesso."
            };
        }
    }
}
